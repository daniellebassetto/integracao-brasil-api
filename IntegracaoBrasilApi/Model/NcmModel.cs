using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Model;

public class NcmModel
{
    public string? Codigo { get; set; }
    public string? Descricao { get; set; }
    [JsonProperty("data_inicio")]
    public DateTime DataInicio { get; set; }
    [JsonProperty("data_fim")]
    public DateTime DataFim { get; set; }
    [JsonProperty("tipo_ato")]
    public string? TipoAto { get; set; }
    [JsonProperty("numero_ato")]
    public string? NumeroAto { get; set; }
    [JsonProperty("ano_ato")]
    public string? AnoAto { get; set; }
}