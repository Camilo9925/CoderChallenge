using CoderChallenge.Arguments.Arguments.Localizacao;
using CoderChallenge.Arguments.Arguments.Superpoder;
using CoderChallenge.Domain.Enums;

namespace CoderChallenge.Arguments.Arguments.Pato;

public class OutputPatoPrimordial
{
    public string? Id { get; set; }
    public float? AlturaCm { get; set; }
    public float? PesoG { get; set; }
    public int? QuantidadeMutacoes { get; set; }
    public EnumStatusHibernacao? StatusHibernacao { get; set; }
    public int? BatimentosCardiacosBpm { get; set; }
    public OutputSuperpoder? Superpoder { get; set; } 
    public OutputLocalizacao? Localizacao { get; set; } 
    public DateTime? DataCatalogacao { get; set; }
    public string? DroneOrigemId { get; set; }
}
