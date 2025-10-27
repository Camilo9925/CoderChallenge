using CoderChallenge.Arguments.Arguments.Localizacao;
using CoderChallenge.Arguments.Arguments.Superpoder;
using CoderChallenge.Domain.Enums;

namespace CoderChallenge.Arguments.Arguments.Pato;

public class InputPatoPrimordial(float alturaCm, string unidadeAltura, float pesoG, string unidadePeso, int quantidadeMutacoes, EnumStatusHibernacao statusHibernacao, InputSuperpoder? superpoder, InputLocalizacao localizacao)
{
    public float AlturaCm { get; set; } = alturaCm;
    public string UnidadeAltura { get; set; } = unidadeAltura;
    public float PesoG { get; set; } = pesoG;
    public string UnidadePeso { get; set; } = unidadePeso;
    public int QuantidadeMutacoes { get; set; } = quantidadeMutacoes;
    public EnumStatusHibernacao StatusHibernacao { get; set; } = statusHibernacao;
    public InputSuperpoder? Superpoder { get; set; } = superpoder;
    public InputLocalizacao Localizacao { get; set; } = localizacao;
}
