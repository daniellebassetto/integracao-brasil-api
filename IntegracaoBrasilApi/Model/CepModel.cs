namespace IntegracaoBrasilApi.Model;

public class CepModel(string? cep, string? logradouro, string? complemento, string? bairro, string? localidade, string? uf, string? ibge, string? gia, string? ddd, string? siafi)
{
    public string? Cep { get; private set; } = cep;
    public string? Logradouro { get; private set; } = logradouro;
    public string? Complemento { get; private set; } = complemento;
    public string? Bairro { get; private set; } = bairro;
    public string? Localidade { get; private set; } = localidade;
    public string? Uf { get; private set; } = uf;
    public string? Ibge { get; private set; } = ibge;
    public string? Gia { get; private set; } = gia;
    public string? Ddd { get; private set; } = ddd;
    public string? Siafi { get; private set; } = siafi;
}