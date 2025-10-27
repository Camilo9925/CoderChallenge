using CoderChallenge.Application.Interfaces;
using CoderChallenge.Arguments.Arguments.Drone;
using CoderChallenge.Arguments.Arguments.Localizacao;
using CoderChallenge.Arguments.Arguments.Precisao;
using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Application.Validators;

public class DroneValidator : IDroneValidator
{
    public void ValidarDroneExistente(DroneEntity drone)
    {
        if (drone == null)
            throw new Exception("Drone não encontrado");

        if (!drone.EstaAtivo())
            throw new Exception("Drone não está ativo");
    }
    public void ValidarInputDrone(InputDrone input)
    {
        var erros = new List<string>();

        if (string.IsNullOrWhiteSpace(input?.NumeroSerie))
            erros.Add("Número de série é obrigatório");
        else if (input.NumeroSerie.Length > 64)
            erros.Add("Número de série não pode ter mais de 64 caracteres");

        if (string.IsNullOrWhiteSpace(input?.Marca))
            erros.Add("Marca é obrigatória");

        if (string.IsNullOrWhiteSpace(input?.Fabricante))
            erros.Add("Fabricante é obrigatório");

        if (string.IsNullOrWhiteSpace(input?.PaisOrigem))
            erros.Add("País de origem é obrigatório");

        if (input?.Localizacao == null)
            erros.Add("Localização é obrigatória");
        else
            ValidarLocalizacao(input.Localizacao, erros);

        if (erros.Count > 0)
        {
            throw new Exception("Validação de Drone falhou " + erros);
        }
    }
    private void ValidarLocalizacao(InputLocalizacao localizacao, List<string> erros)
    {
        if (string.IsNullOrWhiteSpace(localizacao.Cidade))
            erros.Add("Cidade é obrigatória");

        if (string.IsNullOrWhiteSpace(localizacao.Pais))
            erros.Add("País é obrigatório");

        if (localizacao.Latitude < -90 || localizacao.Latitude > 90)
            erros.Add("Latitude deve estar entre -90 e 90");

        if (localizacao.Longitude < -180 || localizacao.Longitude > 180)
            erros.Add("Longitude deve estar entre -180 e 180");
        if(localizacao.Precisao == null)
            erros.Add("Precisao é obrigatória");
        else
            ValidarPrecisao(localizacao.Precisao, erros);
    }
    private void ValidarPrecisao(InputPrecisao precisao, List<string> erros)
    {

        if (precisao == null)
            throw new Exception("Precisão não pode ser nula");

        if (precisao.Valor <= 0)
            erros.Add("Valor da precisão deve ser maior que zero");

        if (string.IsNullOrWhiteSpace(precisao.UnidadeOriginal))
            erros.Add("Unidade da precisão é obrigatória");

        if (precisao.ValorEmMetros <= 0)
            erros.Add("Valor em metros da precisão deve ser maior que zero");

        if (erros.Count > 0)
            throw new Exception("Validação de Precisão falhou: " + string.Join(", ", erros));
    }
}