using CoderChallenge.Arguments.Arguments.Localizacao;

namespace CoderChallenge.Arguments.Arguments.Drone;

public class InputDrone(string numeroSerie, string marca, string fabricante, string paisOrigem, InputLocalizacao localizacao, bool ativo)
{
    public string NumeroSerie { get; set; } = numeroSerie;
    public string Marca { get; set; } = marca;
    public string Fabricante { get; set; } = fabricante;
    public string PaisOrigem { get; set; } = paisOrigem;
    public InputLocalizacao Localizacao { get; set; } = localizacao;
    public bool Ativo { get; set; } = ativo;
}
