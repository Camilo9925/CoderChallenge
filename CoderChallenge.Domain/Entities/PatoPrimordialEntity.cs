using CoderChallenge.Domain.Common;
using CoderChallenge.Domain.Enums;

namespace CoderChallenge.Domain.Entities;

public class PatoPrimordialEntity : BaseEntity
{
    public float AlturaCm { get; set; }
    public string UnidadeAltura { get; set; }
    public float PesoG { get; set; }
    public string UnidadePeso { get; set; }
    public int QuantidadeMutacoes { get; set; }
    public EnumStatusHibernacao StatusHibernacao { get; set; }
    public int? BatimentosCardiacosBpm { get; set; }
    public SuperpoderEntity Superpoder { get; set; }
    public LocalizacaoEntity Localizacao { get; set; }
    public string? DroneOrigemId { get; set; }
    public DateTime DataCatalogacao { get; set; }
    public bool EstaDesperto() => StatusHibernacao == EnumStatusHibernacao.Desperto;
    
    public bool EstaEmTranse() => StatusHibernacao == EnumStatusHibernacao.Transe;
    
    public bool EstaEmHibernacao() => StatusHibernacao == EnumStatusHibernacao.HibernacaoProfunda;
    
    public bool TemSuperPoder() => Superpoder != null;
    
    public void MedirBatimentosCardiacos(int bpm)
    {
        if (EstaDesperto())
            throw new Exception("Não é possível medir batimentos de pato desperto");
        
        BatimentosCardiacosBpm = bpm;
    }
    
    public void RevelarSuperPoder(SuperpoderEntity superpoder)
    {
        if (!EstaDesperto())
            throw new Exception("Só é possível revelar super-poder de pato desperto");
        
        Superpoder = superpoder;
    }
}
