namespace IntegracaoBrasilApi.Model;

public class CnpjModel(string? cnpj, string? razaoSocial, string? nomeFantasia, DateTime dataInicioAtividade, DateTime dataSituacaoCadastral, string? situacaoCadastral, string? uf, string? tipoLogradouro, string? logradouro, string? numero, string? complemento, string? bairro, string? cep, string? municipio)
{
    public string? Cnpj { get; private set; } = cnpj;
    public string? RazaoSocial { get; private set; } = razaoSocial;
    public string? NomeFantasia { get; private set; } = nomeFantasia;
    public DateTime DataInicioAtividade { get; private set; } = dataInicioAtividade;
    public DateTime DataSituacaoCadastral { get; private set; } = dataSituacaoCadastral;
    public string? SituacaoCadastral { get; private set; } = situacaoCadastral;
    public string? Uf { get; private set; } = uf;
    public string? TipoLogradouro { get; private set; } = tipoLogradouro;
    public string? Logradouro { get; private set; } = logradouro;
    public string? Numero { get; private set; } = numero;
    public string? Complemento { get; private set; } = complemento;
    public string? Bairro { get; private set; } = bairro;
    public string? Cep { get; private set; } = cep;
    public string? Municipio { get; private set; } = municipio;
}