namespace IntegracaoBrasilApi.Arguments;

public class InputAuthentication(string username, string password, bool saveFileToken)
{
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
    public bool SaveFileToken { get; private set; } = saveFileToken;
}