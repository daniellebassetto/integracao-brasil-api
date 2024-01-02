using System.Text.Json.Serialization;

namespace IntegracaoBrasilApi.DTOs;

public class NcmDTO
{
    public string? Codigo { get; set; }
    public string? Descricao { get; set; }
    [JsonPropertyName("data_inicio")]
    public DateTime DataInicio { get; set; }
    [JsonPropertyName("data_fim")]
    public DateTime DataFim { get; set; }
    [JsonPropertyName("tipo_ato")]
    public string? TipoAto { get; set; }
    [JsonPropertyName("numero_ato")]
    public string? NumeroAto { get; set; }
    [JsonPropertyName("ano_ato")]
    public string? AnoAto { get; set; }
}