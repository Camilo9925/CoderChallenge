namespace CoderChallenge.Arguments.Arguments.Precisao;

public class InputPrecisao(float valor, string unidadeOriginal, float valorEmMetros)
{
    public float Valor { get; set; } = valor;
    public string UnidadeOriginal { get; set; } = unidadeOriginal;
    public float ValorEmMetros { get; set; } = valorEmMetros;
}
