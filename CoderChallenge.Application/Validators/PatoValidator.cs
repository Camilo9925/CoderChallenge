using CoderChallenge.Application.Interfaces;
using CoderChallenge.Arguments.Arguments.Localizacao;
using CoderChallenge.Arguments.Arguments.Pato;
using CoderChallenge.Arguments.Arguments.Precisao;
using CoderChallenge.Arguments.Arguments.Superpoder;
using CoderChallenge.Domain.Entities;
using CoderChallenge.Domain.Enums;

namespace CoderChallenge.Application.Validators;

public class PatoValidator : IPatoValidator
{
    public void ValidarPatoExistente(PatoPrimordialEntity pato)
    {
        if (pato == null)
            throw new Exception("Pato não encontrado");
        
        if (!pato.Localizacao.CoordenadaValida())
                throw new Exception("Coordenadas do pato inválidas");

        //if (!pato.Localizacao.TemPontoDeReferencia())
            //throw new Exception("Pato não possui ponto de referência conhecido");
    }

    public void ValidarInputPato(InputPatoPrimordial input)
    {
        var erros = new List<string>();

        if (input == null)
        {
            erros.Add("Input do pato não pode ser nulo");
            throw new Exception("Validação de Pato falhou " + string.Join(", ", erros));
        }

        if (input.AlturaCm <= 0)
            erros.Add("Altura deve ser maior que zero");

        if (input.PesoG <= 0)
            erros.Add("Peso deve ser maior que zero");

        if (input.QuantidadeMutacoes < 0)
            erros.Add("Quantidade de mutações não pode ser negativa");

        if (!Enum.IsDefined(typeof(EnumStatusHibernacao), input.StatusHibernacao))
            erros.Add("Status de hibernação inválido");

        if (input.Localizacao == null)
            erros.Add("Localização é obrigatória");
        else
            ValidarLocalizacao(input.Localizacao, erros);

        if (input.Superpoder != null)
            ValidarSuperpoder(input.Superpoder, erros);

        if (erros.Count > 0)
            throw new Exception("Validação de Pato falhou " + string.Join(", ", erros));
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

        if (localizacao.Precisao == null)
            erros.Add("Precisão é obrigatória");
        else
            ValidarPrecisao(localizacao.Precisao, erros);
    }

    private void ValidarPrecisao(InputPrecisao precisao, List<string> erros)
    {
        if (precisao.Valor <= 0)
            erros.Add("Valor da precisão deve ser maior que zero");

        if (string.IsNullOrWhiteSpace(precisao.UnidadeOriginal))
            erros.Add("Unidade da precisão é obrigatória");

        if (precisao.ValorEmMetros <= 0)
            erros.Add("Valor em metros da precisão deve ser maior que zero");
    }

    private void ValidarSuperpoder(InputSuperpoder superpoder, List<string> erros)
    {
        if (string.IsNullOrWhiteSpace(superpoder.Nome))
            erros.Add("Nome do superpoder é obrigatório");

        if (string.IsNullOrWhiteSpace(superpoder.Descricao))
            erros.Add("Descrição do superpoder é obrigatória");

        if (superpoder.Classificacoes == null || !superpoder.Classificacoes.Any())
            erros.Add("Classificações do superpoder são obrigatórias");
    }
}
