using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Arguments.Arguments.Localizacao;
using CoderChallenge.Arguments.Arguments.Pato;
using CoderChallenge.Arguments.Arguments.Precisao;
using CoderChallenge.Arguments.Arguments.Superpoder;
using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Application.Mappers;

public static class PatoPrimordialMapper
{
    public static OutputPatoPrimordial PatoPrimordialEntityToOutput(PatoPrimordialEntity patoPrimordialEntity)
    {
        try
        {
            OutputPatoPrimordial entity = new OutputPatoPrimordial
            {
                Id = patoPrimordialEntity.Id,
                AlturaCm = patoPrimordialEntity.AlturaCm,
                PesoG = patoPrimordialEntity.PesoG,
                QuantidadeMutacoes = patoPrimordialEntity.QuantidadeMutacoes,
                StatusHibernacao = patoPrimordialEntity.StatusHibernacao,
                BatimentosCardiacosBpm = patoPrimordialEntity.BatimentosCardiacosBpm,
                DataCatalogacao = patoPrimordialEntity.DataCatalogacao,
                DroneOrigemId = patoPrimordialEntity.DroneOrigemId,
                Localizacao = patoPrimordialEntity.Localizacao != null ? new OutputLocalizacao
                {
                    Id = patoPrimordialEntity.Localizacao.Id,
                    Cidade = patoPrimordialEntity.Localizacao.Cidade,
                    Latitude = patoPrimordialEntity.Localizacao.Latitude,
                    Longitude = patoPrimordialEntity.Localizacao.Longitude,
                    Pais = patoPrimordialEntity.Localizacao.Pais,
                    PontoReferenciaConhecido = patoPrimordialEntity.Localizacao.PontoReferenciaConhecido,
                    Precisao = patoPrimordialEntity.Localizacao.Precisao != null ? new OutputPrecisao
                    {
                        Id = patoPrimordialEntity.Localizacao.Precisao.Id,
                        UnidadeOriginal = patoPrimordialEntity.Localizacao.Precisao.UnidadeOriginal,
                        Valor = patoPrimordialEntity.Localizacao.Precisao.Valor,
                        ValorEmMetros = patoPrimordialEntity.Localizacao.Precisao.ValorEmMetros
                    } : null
                } : null,
                Superpoder = patoPrimordialEntity.Superpoder != null ? new OutputSuperpoder
                {
                    Id = patoPrimordialEntity.Superpoder.Id,
                    Classificacoes = patoPrimordialEntity.Superpoder.Classificacoes,
                    Descricao = patoPrimordialEntity.Superpoder.Descricao,
                    Nome = patoPrimordialEntity.Superpoder.Nome
                } : null
            };

            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao mapear pato: {ex.Message}");
            throw;
        }
    }

    public static PatoPrimordialEntity PatoPrimordialInputToEntity(InputPatoPrimordial input, IConversaoUnidadeService conversaoService)
    {
        try
        {            
            float alturaCmConvertida = conversaoService.ConverterAlturaPesParaCm(input.AlturaCm, input.UnidadeAltura);
            float pesoGConvertido = conversaoService.ConverterPesoLibrasParaGramas(input.PesoG, input.UnidadePeso);

            PatoPrimordialEntity entity = new PatoPrimordialEntity
            {
                AlturaCm = alturaCmConvertida,
                UnidadeAltura = input.UnidadeAltura,   
                PesoG = pesoGConvertido,
                UnidadePeso = input.UnidadePeso,       
                QuantidadeMutacoes = input.QuantidadeMutacoes,
                StatusHibernacao = input.StatusHibernacao,
                Superpoder = input.Superpoder != null ? new SuperpoderEntity
                {
                    Nome = input.Superpoder.Nome,
                    Classificacoes = input.Superpoder.Classificacoes,
                    Descricao = input.Superpoder.Descricao,
                } : null,
                Localizacao = input.Localizacao != null ? new LocalizacaoEntity
                {
                    Cidade = input.Localizacao.Cidade,
                    Latitude = input.Localizacao.Latitude,
                    Longitude = input.Localizacao.Longitude,
                    Pais = input.Localizacao.Pais,
                    PontoReferenciaConhecido = input.Localizacao.PontoReferenciaConhecido,
                    Precisao = input.Localizacao.Precisao != null ? new PrecisaoEntity
                    {
                        UnidadeOriginal = input.Localizacao.Precisao.UnidadeOriginal,
                        Valor = input.Localizacao.Precisao.Valor,
                        ValorEmMetros = conversaoService.ConverterPrecisaoParaMetros(
                            input.Localizacao.Precisao.Valor,
                            input.Localizacao.Precisao.UnidadeOriginal)
                    } : null
                } : null
            };

            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao mapear pato: {ex.Message}");
            throw;
        }
    }

}
