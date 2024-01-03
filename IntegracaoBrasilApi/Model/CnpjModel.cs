using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Model;

public class CnpjModel
{
    public string? Cnpj { get; set; }
    [JsonProperty("razao_social")]
    public string? RazaoSocial { get; set; }
    [JsonProperty("nome_fantasia")]
    public string? NomeFantasia { get; set; }
    [JsonProperty("data_inicio_atividade")]
    public DateTime DataInicioAtividade { get; set; }
    [JsonProperty("data_situacao_cadastral")]
    public DateTime DataSituacaoCadastral { get; set; }
    [JsonProperty("descricao_situacao_cadastral")]
    public string? SituacaoCadastral { get; set; }
    public string? Uf { get; set; }
    [JsonProperty("descricao_tipo_de_logradouro")]
    public string? TipoLogradouro { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Cep { get; set; }
    public string? Municipio { get; set; }
}