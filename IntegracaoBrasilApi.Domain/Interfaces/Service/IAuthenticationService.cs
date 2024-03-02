using IntegracaoBrasilApi.Arguments;

namespace IntegracaoBrasilApi.Domain.Interfaces.Service;

public interface IAuthenticationService : IBaseService_0
{
    OutputAuthentication? Authenticate(InputAuthentication inputAuthentication);
}