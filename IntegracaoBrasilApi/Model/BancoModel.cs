using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Model;

public class BancoModel
{
    public string? Ispb { get; set; }
    [JsonProperty("name")]
    public string? Nome { get; set; }
    [JsonProperty("fullName")]
    public string? NomeCompleto { get; set; }
}