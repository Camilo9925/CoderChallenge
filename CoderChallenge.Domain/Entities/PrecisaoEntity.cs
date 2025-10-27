using CoderChallenge.Domain.Common;

namespace CoderChallenge.Domain.Entities;

public class PrecisaoEntity : BaseEntity
{
    public float Valor { get; set; }
    public string UnidadeOriginal { get; set; }
    public float ValorEmMetros { get; set; }
    public bool MuitoPreciso() => ValorEmMetros <= 0.5f;
    
    public bool Preciso() => ValorEmMetros <= 5f;
    
    public bool Impreciso() => ValorEmMetros > 20f;
}
