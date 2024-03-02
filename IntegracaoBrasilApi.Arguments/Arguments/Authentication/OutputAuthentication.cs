namespace IntegracaoBrasilApi.Arguments;

public class OutputAuthentication(string token, DateTime expirationDate)
{
    public string Token { get; set; } = token;
    public DateTime ExpirationDate { get; set; } = expirationDate;
}