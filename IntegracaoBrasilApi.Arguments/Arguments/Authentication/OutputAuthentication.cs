namespace IntegracaoBrasilApi.Arguments;

public class OutputAuthentication(string message, string token, DateTime? tokenExpirationDate)
{
    public string Message { get; set; } = message;
    public string? Token { get; set; } = token;
    public DateTime? TokenExpirationDate { get; set; } = tokenExpirationDate;
}