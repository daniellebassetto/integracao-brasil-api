using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Arguments;

public class SecondaryCnae
{
    [JsonProperty("codigo")] public int? Code { get; set; }
    [JsonProperty("descricao")] public string? Description { get; set; } = string.Empty;
}