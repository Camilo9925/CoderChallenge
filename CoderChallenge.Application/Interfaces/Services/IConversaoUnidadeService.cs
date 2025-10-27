namespace CoderChallenge.Application.Interfaces.Services;

public interface IConversaoUnidadeService
{
    float ConverterPrecisaoParaMetros(float valor, string unidade);
    float ConverterAlturaPesParaCm(float altura, string unidade);
    float ConverterPesoLibrasParaGramas(float peso, string unidade);
}