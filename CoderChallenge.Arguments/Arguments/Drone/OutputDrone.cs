using CoderChallenge.Arguments.Arguments.Localizacao;

namespace CoderChallenge.Arguments.Arguments.Drone;

public class OutputDrone
{
    public string? Id { get; set; }
    public string? NumeroSerie { get; set; }
    public string? Marca { get; set; }
    public string? Fabricante { get; set; }
    public string? PaisOrigem { get; set; }
    public OutputLocalizacao? Localizacao { get; set; }
    public bool? Ativo { get; set; }
    public DateTime? DataCriacao { get; set; }
    public DateTime? DataDestruicao { get; set; }
}
