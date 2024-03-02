using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Interfaces.Repository;
using IntegracaoBrasilApi.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegracaoBrasilApi.Domain.Services;

public class AuthenticationService(IHttpContextAccessor httpContext, IUserRepository userRepository) : BaseService_0, IAuthenticationService
{
    private readonly HttpContext _httpContext = httpContext.HttpContext;
    private readonly IUserRepository _userRepository = userRepository;

    public OutputAuthentication? Authenticate(InputAuthentication inputAuthentication)
    {
        var user = _userRepository.GetByIdentifier(new InputIdentifierUser(inputAuthentication.Username));
        if (user is not null)
        {
            return new OutputAuthentication(GenerateJwtToken(user.Id, user.Username), DateTime.Now);
        }
        return null;
    }

    private string GenerateJwtToken(string userId, string userName)
    {
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Iss, _httpContext.Request.Host.Value),
            new(JwtRegisteredClaimNames.Sub, userName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes("63bcc5be-fa37-4290-b5a4-57a6a4e3afcb"));
        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);
        DateTime expires = DateTime.Now.AddHours(24);

        JwtSecurityToken token = new(
            _httpContext.Request.Host.Value,
            userId,
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}