namespace IntegracaoBrasilApi.Model;

public class BancoModel(string? ispb, string? nome, string? nomeCompleto)
{
    public string? Ispb { get; private set; } = ispb;
    public string? Nome { get; private set; } = nome;
    public string? NomeCompleto { get; private set; } = nomeCompleto;
}