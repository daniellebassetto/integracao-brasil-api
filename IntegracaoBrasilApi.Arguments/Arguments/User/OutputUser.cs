namespace IntegracaoBrasilApi.Arguments;

public class OutputUser
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime? TokenExpirationDate { get; set; }
}