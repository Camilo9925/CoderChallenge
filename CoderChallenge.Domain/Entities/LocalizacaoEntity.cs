using CoderChallenge.Domain.Common;

namespace CoderChallenge.Domain.Entities;

public class LocalizacaoEntity : BaseEntity
{
    public string Cidade { get; set; }
    public string Pais { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public PrecisaoEntity Precisao { get; set; }
    public string PontoReferenciaConhecido { get; set; }
    // public bool TemPontoDeReferencia() => !string.IsNullOrWhiteSpace(PontoReferenciaConhecido);    
    public bool CoordenadaValida() => 
        Latitude >= -90 && Latitude <= 90 &&
        Longitude >= -180 && Longitude <= 180;
}
    