namespace IntegracaoBrasilApi.Domain.Entities;

public class User(string username, string password) : BaseEntity<User>
{
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
}