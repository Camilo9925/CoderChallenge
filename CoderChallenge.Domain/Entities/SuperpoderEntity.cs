using CoderChallenge.Domain.Common;

namespace CoderChallenge.Domain.Entities;

public class SuperpoderEntity : BaseEntity
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string> Classificacoes { get; set; }

    public bool EhBelico() => Classificacoes.Contains("bélico");    
    public bool EhRaro() => Classificacoes.Contains("raro");    
    public bool EhMuitoRaro() => Classificacoes.Contains("muito raro");    
    public bool EhLendario() => Classificacoes.Contains("lendário");
}
