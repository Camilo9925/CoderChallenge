namespace CoderChallenge.Domain.Common;

public class BaseApiResponse<T>
{
    public bool Sucesso { get; set; }
    public T Dados { get; set; }
    public string Mensagem { get; set; }
    public List<string> Erros { get; set; } = new();

    public static BaseApiResponse<T> Ok(T dados, string mensagem)
    {
        return new BaseApiResponse<T>
        {
            Sucesso = true,
            Dados = dados,
            Mensagem = mensagem
        };
    }
    public static BaseApiResponse<T> Erro(string mensagem, List<string> erros = null)
    {
        return new BaseApiResponse<T>
        {
            Sucesso = false,
            Dados = default,
            Mensagem = mensagem,
            Erros = erros ?? new()
        };
    }
}
