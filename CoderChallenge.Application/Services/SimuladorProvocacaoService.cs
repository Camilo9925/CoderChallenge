using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Arguments.Arguments.BuscaPato;
using CoderChallenge.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CoderChallenge.Application.Services;

public class SimuladorProvocacaoService : ISimuladorProvocacaoService
{
    private readonly ISuperpoderService _superpoderService;   

    public SimuladorProvocacaoService(ISuperpoderService superpoderService)
    {
        _superpoderService = superpoderService ?? throw new ArgumentNullException(nameof(superpoderService));
    }

    public async Task<OutputResultadoProvocacaoPato> SimularProvocacaoAsync(PatoPrimordialEntity pato, DroneEntity drone)
    {
        try
        {
            if (pato == null || drone == null)
                throw new ArgumentNullException("Pato e Drone não podem ser null");

            float taxaSucesso = 50f;

            taxaSucesso -= (pato.QuantidadeMutacoes * 5f);

            if (pato.Localizacao?.Precisao != null)
            {
                if (pato.Localizacao.Precisao.MuitoPreciso())
                    taxaSucesso += 10f;
                else if (pato.Localizacao.Precisao.Preciso())
                    taxaSucesso += 5f;
            }

            var idadeDrone = DateTime.UtcNow - drone.DataCriacao;
            if (idadeDrone.TotalDays > 365)
                taxaSucesso -= 15f;

            var random = new Random();
            var sorte = (random.Next(-10, 11));
            taxaSucesso += sorte;

            taxaSucesso = Math.Max(5f, Math.Min(95f, taxaSucesso));

            var resultadoAleatorio = random.Next(0, 100);
            var sucesso = resultadoAleatorio < taxaSucesso;

            return new OutputResultadoProvocacaoPato
            {
                Sucesso = sucesso,
                TaxaSucessoCalculada = (int)taxaSucesso,
                DescricaoFenomeno = sucesso
                    ? $"O pato foi provocado! Seu super-poder foi revelado!"
                    : $"O pato contra-atacou com fúria! O drone foi destruído em uma explosão de energia!"
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao simular provocação: {ex.Message}");
            throw;
        }

    }
    public SuperpoderEntity GerarSuperpoderAleatorio()
    {
        return _superpoderService.GerarSuperpoderAleatorio();
    }
}
