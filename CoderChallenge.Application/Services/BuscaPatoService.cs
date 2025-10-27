using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Arguments.Arguments.BuscaPato;
using CoderChallenge.Arguments.Arguments.Localizacao;
using CoderChallenge.Arguments.Arguments.Precisao;
using CoderChallenge.Arguments.Arguments.Superpoder;
using CoderChallenge.Domain.Common;
using CoderChallenge.Domain.Entities;
using CoderChallenge.Infrastructure.Repository.Interfaces;

namespace CoderChallenge.Application.Services;

public class BuscaPatoService : IBuscaPatoService
{
    private readonly IDroneRepository _droneRepository;
    private readonly IPatoRepository _patoRepository;
    private readonly IBuscaPatoRepository _buscaPatoRepository;
    private readonly ISimuladorProvocacaoService _simuladorService;
    private readonly IConversaoUnidadeService _conversaoUnidade;

    public BuscaPatoService(IDroneRepository droneRepository, IPatoRepository patoRepository, IBuscaPatoRepository buscaPatoRepository, ISimuladorProvocacaoService simuladorService, IConversaoUnidadeService conversaoUnidade)
    {
        _droneRepository = droneRepository;
        _patoRepository = patoRepository;
        _buscaPatoRepository = buscaPatoRepository;
        _simuladorService = simuladorService;
        _conversaoUnidade = conversaoUnidade;
    }

    public async Task<BaseApiResponse<OutputBuscaPato>> ExecutarBuscaPatoAsync(string droneId, string patoIdEspecifico = null)
    {
        try
        {
            var drone = await _droneRepository.ObterDronePorId(droneId);
            if (drone == null)
                return BaseApiResponse<OutputBuscaPato>.Erro("Drone não encontrado");

            if (!drone.EstaAtivo())
                return BaseApiResponse<OutputBuscaPato>.Erro("Drone não está ativo");

            PatoPrimordialEntity pato;

            if (!string.IsNullOrWhiteSpace(patoIdEspecifico))
            {
                pato = await _buscaPatoRepository.BuscarPatoPorId(patoIdEspecifico);
                if (pato == null)
                {
                    return BaseApiResponse<OutputBuscaPato>.Ok(
                        new OutputBuscaPato
                        {
                            PatoEncontrado = false,
                            Mensagem = "Pato específico não encontrado",
                            Etapa = "busca_sem_resultado"
                        },
                        "Busca concluída sem encontrar o pato específico");
                }
            }
            else
            {
                pato = await _buscaPatoRepository.BuscarPatoAleatorio();
                if (pato == null)
                {
                    return BaseApiResponse<OutputBuscaPato>.Ok(
                        new OutputBuscaPato
                        {
                            PatoEncontrado = false,
                            Mensagem = "Drone não encontrou nenhum pato na região",
                            Etapa = "busca_sem_resultado"
                        },
                        "Busca concluída sem encontrar patos");
                }
            }
                        
            pato.DroneOrigemId = drone.Id;
                        
            pato.AlturaCm = _conversaoUnidade.ConverterAlturaPesParaCm(pato.AlturaCm, pato.UnidadeAltura ?? "cm");
            pato.PesoG = _conversaoUnidade.ConverterPesoLibrasParaGramas(pato.PesoG, pato.UnidadePeso ?? "g");

            await _patoRepository.AtualizarPato(pato.Id, pato);
                        
            var precisaoMetros = _conversaoUnidade.ConverterPrecisaoParaMetros(pato.Localizacao.Precisao.Valor, pato.Localizacao.Precisao.UnidadeOriginal);

            var resultado = new OutputBuscaPato
            {
                PatoEncontrado = true,
                PatoId = pato.Id,
                StatusPatoEncontrado = pato.StatusHibernacao.ToString(),
                DroneNumeroSerie = drone.NumeroSerie,
                DroneMarca = drone.Marca,
                DroneFabricante = drone.Fabricante,
                DronePaisOrigem = drone.PaisOrigem,
                AlturaCm = pato.AlturaCm,
                PesoG = pato.PesoG,
                Localizacao = new OutputLocalizacao
                {
                    Id = pato.Localizacao.Id,
                    Cidade = pato.Localizacao.Cidade,
                    Pais = pato.Localizacao.Pais,
                    Latitude = pato.Localizacao.Latitude,
                    Longitude = pato.Localizacao.Longitude,
                    PontoReferenciaConhecido = pato.Localizacao.PontoReferenciaConhecido,
                    Precisao = new OutputPrecisao
                    {
                        Id = pato.Localizacao.Precisao.Id,
                        Valor = pato.Localizacao.Precisao.Valor,
                        UnidadeOriginal = pato.Localizacao.Precisao.UnidadeOriginal,
                        ValorEmMetros = precisaoMetros
                    }
                }
            };

            if (pato.EstaEmTranse() || pato.EstaEmHibernacao())
            {
                var batimentos = new Random().Next(40, 180);
                pato.MedirBatimentosCardiacos(batimentos);
                await _patoRepository.AtualizarPato(pato.Id, pato);

                resultado.Etapa = "medicao_batimentos";
                resultado.BatimentosCardiacosMedidos = batimentos;
                resultado.Mensagem = $"Batimentos medidos: {batimentos} BPM";
                resultado.DescricaoFenomeno = $"O pato em {pato.StatusHibernacao} apresenta {batimentos} BPM. Seu coração bate de forma constante.";
            }
            else if (pato.EstaDesperto())
            {
                var resultadoProvocacao = await _simuladorService.SimularProvocacaoAsync(pato, drone);

                if (resultadoProvocacao.Sucesso)
                {
                    var superpoder = new SuperpoderEntity();
                    if (pato.Superpoder is null)
                        superpoder = _simuladorService.GerarSuperpoderAleatorio();
                    else
                        superpoder = pato.Superpoder;
                        
                    pato.RevelarSuperPoder(superpoder);
                    await _patoRepository.AtualizarPato(pato.Id, pato);
                    resultado.Etapa = "provocacao_sucesso";
                    resultado.Superpoder = new OutputSuperpoder
                    {
                        Nome = superpoder.Nome,
                        Descricao = superpoder.Descricao,
                        Classificacoes = superpoder.Classificacoes
                    };
                    resultado.Mensagem = $"Super-poder revelado: {superpoder.Nome}";
                    resultado.DescricaoFenomeno = resultadoProvocacao.DescricaoFenomeno;
                }
                else
                {
                    drone.Destruir();
                    await _droneRepository.AtualizarDrone(drone.Id, drone);

                    resultado.Etapa = "provocacao_falha";
                    resultado.DroneDestruido = true;
                    resultado.Mensagem = "Drone destruído pelo pato!";
                    resultado.DescricaoFenomeno = resultadoProvocacao.DescricaoFenomeno;
                }

                resultado.TaxaSucessoCalculada = resultadoProvocacao.TaxaSucessoCalculada;
            }

            return BaseApiResponse<OutputBuscaPato>.Ok(resultado, "Busca de pato concluída");
        }
        catch (Exception ex)
        {
            return BaseApiResponse<OutputBuscaPato>.Erro(
                "Erro ao executar busca de pato",
                new List<string> { ex.Message });
        }
    }
}