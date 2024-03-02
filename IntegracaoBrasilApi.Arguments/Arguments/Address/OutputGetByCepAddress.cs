namespace IntegracaoBrasilApi.Arguments;

public class OutputGetByCepAddress
{
    public string? Cep { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Neighborhood { get; set; }
    public string? Street { get; set; }
    public Location? Location { get; set; }
}