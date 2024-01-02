using System.Text.Json.Serialization;

namespace IntegracaoBrasilApi.DTOs;

public class CnpjDTO
{
    public string? Cnpj { get; set; }
    [JsonPropertyName("razao_social")]
    public string? RazaoSocial { get; set; }
    [JsonPropertyName("nome_fantasia")]
    public string? NomeFantasia { get; set; }
    [JsonPropertyName("data_inicio_atividade")]
    public DateTime DataInicioAtividade { get; set; }
    [JsonPropertyName("data_situacao_cadastral")]
    public DateTime DataSituacaoCadastral { get; set; }
    [JsonPropertyName("descricao_situacao_cadastral")]
    public string? SituacaoCadastral { get; set; }
    public string? Uf { get; set; }
    [JsonPropertyName("descricao_tipo_de_logradouro")]
    public string? TipoLogradouro { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Cep { get; set; }
    public string? Municipio { get; set; }
}