using System.Text.Json.Serialization;

namespace IntegracaoBrasilApi.DTOs;

public class FeriadoDTO
{
    [JsonPropertyName("date")]
    public DateTime Data { get; set; }
    [JsonPropertyName("name")]
    public string? Nome { get; set; }
    [JsonPropertyName("type")]
    public string? Tipo { get; set; }
}