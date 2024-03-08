using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Entities;

namespace IntegracaoBrasilApi.Domain.Interfaces.Repository;

public interface IUserRepository : IBaseRepository<User, InputIdentifierUser> { }