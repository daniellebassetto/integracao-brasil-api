using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Model;

public class FeriadoModel
{
    [JsonProperty("date")]
    public DateTime Data { get; set; }
    [JsonProperty("name")]
    public string? Nome { get; set; }
    [JsonProperty("type")]
    public string? Tipo { get; set; }
}