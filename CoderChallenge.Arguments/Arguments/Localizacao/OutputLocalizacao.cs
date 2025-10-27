using CoderChallenge.Arguments.Arguments.Precisao;

namespace CoderChallenge.Arguments.Arguments.Localizacao;

public class OutputLocalizacao
{
    public string? Id { get; set; }
    public string? Cidade { get; set; }
    public string? Pais { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? PontoReferenciaConhecido { get; set; }
    public OutputPrecisao? Precisao { get; set; }
}
