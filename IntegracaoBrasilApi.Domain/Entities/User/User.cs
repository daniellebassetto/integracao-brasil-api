namespace IntegracaoBrasilApi.Domain.Entities;

public class User(string username, string password, DateTime? tokenExpirationDate) : BaseEntity<User>
{
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
    public DateTime? TokenExpirationDate { get; private set; } = tokenExpirationDate;
}