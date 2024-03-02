using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Arguments;

public class Location
{
    public string? Type { get; set; }
    [JsonProperty("coordinates")] public Coordinate? Coordinate { get; set; }
}