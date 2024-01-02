namespace IntegracaoBrasilApi.Model;

public class FeriadoModel(DateTime data, string? nome, string? tipo)
{
    public DateTime Data { get; private set; } = data;
    public string? Nome { get; private set; } = nome;
    public string? Tipo { get; private set; } = tipo;
}