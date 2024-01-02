using System.Text.Json.Serialization;

namespace IntegracaoBrasilApi.DTOs;

public class BancoDTO
{
    public string? Ispb { get; set; }
    [JsonPropertyName("name")]
    public string? Nome { get; set; }
    [JsonPropertyName("fullName")]
    public string? NomeCompleto { get; set; }
}