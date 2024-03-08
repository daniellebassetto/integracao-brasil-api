using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Entities;
using IntegracaoBrasilApi.Domain.Interfaces.Repository;
using IntegracaoBrasilApi.Infraestructure.Context;

namespace IntegracaoBrasilApi.Infraestructure.Repository;

public class UserRepository(IMongoContext context) : BaseRepository<User, InputIdentifierUser>(context), IUserRepository { }