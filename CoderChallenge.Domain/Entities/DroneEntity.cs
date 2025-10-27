using CoderChallenge.Domain.Common;

namespace CoderChallenge.Domain.Entities;

public class DroneEntity : BaseEntity
{
    public string NumeroSerie { get; set; }
    public string Marca { get; set; }
    public string Fabricante { get; set; }  
    public string PaisOrigem { get; set; }
    public LocalizacaoEntity Localizacao { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataDestruicao { get; set; }
    public void Destruir()
    {
        Ativo = false;
        DataDestruicao = DateTime.UtcNow;
    }
    
    public bool EstaAtivo() => Ativo;    
    public bool FoiDestruido() => !Ativo && DataDestruicao.HasValue;
}
