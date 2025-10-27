using CoderChallenge.Arguments.Arguments.Precisao;
using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Arguments.Arguments.Localizacao;

public class InputLocalizacao(string cidade, string pais, double latitude, double longitude, InputPrecisao precisao, string? pontoReferenciaConhecido)
{
    public string Cidade { get; set; } = cidade;
    public string Pais { get; set; } = pais;
    public double Latitude { get; set; } = latitude;
    public double Longitude { get; set; }  = longitude;
    public InputPrecisao Precisao { get; set; } = precisao;
    public string? PontoReferenciaConhecido { get; set; } = pontoReferenciaConhecido;
}
