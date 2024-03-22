namespace IntegracaoBrasilApi.Arguments;

public class OutputGetByPostalCodeAddress
{
    public string? Cep { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Neighborhood { get; set; }
    public string? Street { get; set; }
    public Location? Location { get; set; }
}