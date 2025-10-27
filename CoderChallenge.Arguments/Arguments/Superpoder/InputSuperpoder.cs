namespace CoderChallenge.Arguments.Arguments.Superpoder;

public class InputSuperpoder(string nome, string descricao, List<string>? classificacoes)
{
    public string Nome { get; set; } = nome;
    public string Descricao { get; set; } = descricao;
    public List<string>? Classificacoes { get; set; } = classificacoes;
}
