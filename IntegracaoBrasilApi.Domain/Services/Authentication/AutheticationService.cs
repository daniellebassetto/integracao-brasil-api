using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.ApiManagement;
using IntegracaoBrasilApi.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegracaoBrasilApi.Domain.Services;

public class AuthenticationService(IHttpContextAccessor httpContext, IUserService userService) : BaseService_0, IAuthenticationService
{
    private readonly HttpContext _httpContext = httpContext.HttpContext;
    private readonly IUserService _userService = userService;

    public OutputAuthentication? Authenticate(InputAuthentication inputAuthentication)
    {
        OutputUser user = _userService.GetByIdentifier(new InputIdentifierUser(inputAuthentication.Username));
        if (user is not null)
        {
            if (inputAuthentication.Password == user.Password)
            {
                var token = GenerateJwtToken(user.Id, user.Username);

                if (inputAuthentication.SaveFileToken)
                {
                    try
                    {
                        var fileContent = token;
                        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        var filePath = Path.Combine(desktopPath, "IntegracaoBrasilApi-BearerToken.txt");
                        File.WriteAllText(filePath, fileContent);
                    }
                    catch(Exception ex) 
                    {
                        return new OutputAuthentication($"Usuário autorizado, porém ocorreram problemas para salvar um arquivo do Token: '{ex.Message}'. Configure seu novo Bearer Token.", token, DateTime.UtcNow.AddDays(7));
                    }
                }

                _userService.Update(new InputIdentityUpdateUser(user.Id, new InputUpdateUser(user.Username, user.Password, DateTime.UtcNow.AddDays(7))));

                return new OutputAuthentication("Usuário autorizado. Configure seu novo Bearer Token.", token, DateTime.UtcNow.AddDays(7));
            }
            else
                return new OutputAuthentication("Usuário não autorizado. Senha incorreta.", string.Empty, null);
        }
        else
            return new OutputAuthentication("Usuário não existe. Cadastre seu usuário no endpoint aberto POST '/api/User'", string.Empty, null);
    }

    private string GenerateJwtToken(string userId, string userName)
    {
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Iss, _httpContext.Request.Host.Value),
            new(JwtRegisteredClaimNames.Sub, userName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(SecurityKeyJwt.Key));
        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);
        var expireDate = DateTime.UtcNow.AddDays(7);

        JwtSecurityToken token = new(
            _httpContext.Request.Host.Value,
            userId,
            claims,
            expires: expireDate,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}