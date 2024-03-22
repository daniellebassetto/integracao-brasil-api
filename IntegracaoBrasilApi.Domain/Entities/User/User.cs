namespace IntegracaoBrasilApi.Domain.Entities;

public class User : BaseEntity<User>
{
    public string? Username { get; private set; }
    public string? Password { get; private set; }
    public DateTime? TokenExpirationDate { get; private set; }

    public User() { }

    public User(string? username, string? password, DateTime? tokenExpirationDate)
    {
        Username = username;
        Password = password;
        TokenExpirationDate = tokenExpirationDate;
    }
}