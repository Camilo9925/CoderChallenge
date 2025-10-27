using CoderChallenge.Arguments.Arguments.Drone;
using CoderChallenge.Arguments.Arguments.Localizacao;
using CoderChallenge.Arguments.Arguments.Precisao;
using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Application.Mappers;

public static class DroneMapper
{
    public static DroneEntity InputDroneToEntity(InputDrone input)
    {
        try
        {
            var entity = new DroneEntity
            {
                NumeroSerie = input.NumeroSerie,
                Marca = input.Marca,
                Fabricante = input.Fabricante,
                PaisOrigem = input.PaisOrigem,
                Ativo = true,
                DataCriacao = DateTime.UtcNow,
                Localizacao = new LocalizacaoEntity
                {
                    Cidade = input.Localizacao.Cidade,
                    Pais = input.Localizacao.Pais,
                    Latitude = input.Localizacao.Latitude,
                    Longitude = input.Localizacao.Longitude,
                    Precisao = new PrecisaoEntity
                    {
                        Valor = input.Localizacao.Precisao.Valor,
                        UnidadeOriginal = input.Localizacao.Precisao.UnidadeOriginal,
                        ValorEmMetros = input.Localizacao.Precisao.ValorEmMetros
                    },
                    PontoReferenciaConhecido = input.Localizacao.PontoReferenciaConhecido
                }
            };

            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao mapear drone: {ex.Message}");
            throw;
        }
    }
    public static OutputDrone DroneEntityToOutputDrone(DroneEntity drone)
    {
        if (drone == null)
            throw new Exception("Drone não pode ser nulo");

        try
        {
            return new OutputDrone
            {
                Id = drone.Id,
                NumeroSerie = drone.NumeroSerie,
                Marca = drone.Marca,
                Fabricante = drone.Fabricante,
                PaisOrigem = drone.PaisOrigem,
                Localizacao = new OutputLocalizacao
                {
                    Id = drone.Localizacao.Id,
                    Cidade = drone.Localizacao.Cidade,
                    Pais = drone.Localizacao.Pais,
                    Latitude = drone.Localizacao.Latitude,
                    Longitude = drone.Localizacao.Longitude,
                    PontoReferenciaConhecido = drone.Localizacao.PontoReferenciaConhecido,
                    Precisao = new OutputPrecisao
                    {
                        Id = drone.Localizacao.Precisao.Id,
                        Valor = drone.Localizacao.Precisao.Valor,
                        UnidadeOriginal = drone.Localizacao.Precisao.UnidadeOriginal,
                        ValorEmMetros = drone.Localizacao.Precisao.ValorEmMetros
                    },

                },
                Ativo = drone.Ativo,
                DataCriacao = drone.DataCriacao,
                DataDestruicao = drone.DataDestruicao
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao mapear drone para output: {ex.Message}");
            throw;
        }
    }
}