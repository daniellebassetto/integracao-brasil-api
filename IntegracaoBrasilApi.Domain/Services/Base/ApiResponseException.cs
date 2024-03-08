namespace IntegracaoBrasilApi.Domain.Services;

public class ApiResponseException
{
    public string? Message { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
}