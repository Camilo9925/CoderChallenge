using CoderChallenge.Arguments.Arguments.Localizacao;
using CoderChallenge.Arguments.Arguments.Superpoder;

namespace CoderChallenge.Arguments.Arguments.BuscaPato;

public class OutputBuscaPato
{
    public string Mensagem { get; set; }
    public string Etapa { get; set; }
    public bool PatoEncontrado { get; set; }
    public string PatoId { get; set; }
    public string StatusPatoEncontrado { get; set; }
    public bool DroneDestruido { get; set; }
    public int? BatimentosCardiacosMedidos { get; set; }
    public int? TaxaSucessoCalculada { get; set; }
    public OutputSuperpoder Superpoder { get; set; }
    public string DescricaoFenomeno { get; set; }
    public string DroneNumeroSerie { get; set; }
    public string DroneMarca { get; set; }
    public string DroneFabricante { get; set; }
    public string DronePaisOrigem { get; set; }
    public float AlturaCm { get; set; }
    public float PesoG { get; set; }
    public OutputLocalizacao Localizacao { get; set; }
}
