using IntegracaoBrasilApi.Arguments;

namespace IntegracaoBrasilApi.Domain.Interfaces.Service;

public interface IUserService : IBaseService<InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser, InputIdentifierUser> { }