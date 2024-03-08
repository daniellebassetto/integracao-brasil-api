using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Entities;
using IntegracaoBrasilApi.Domain.Interfaces.Repository;
using IntegracaoBrasilApi.Domain.Interfaces.Service;

namespace IntegracaoBrasilApi.Domain.Services;

public class UserService(IUserRepository? repository) : BaseService_1<IUserRepository, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, User, OutputUser, InputIdentifierUser>(repository), IUserService { }