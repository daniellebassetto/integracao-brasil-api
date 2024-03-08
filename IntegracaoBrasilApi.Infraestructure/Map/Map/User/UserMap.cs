using IntegracaoBrasilApi.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace IntegracaoBrasilApi.Infraestructure.Map.Map;

public static class UserMap
{
    public static void Map()
    {
        BsonClassMap.RegisterClassMap<User>(x =>
        {
            x.AutoMap();

            x.MapMember(m => m.Username).SetElementName("usuario");
            x.MapMember(m => m.Password).SetElementName("senha");
            x.MapMember(m => m.TokenExpirationDate).SetElementName("data_expiracao_token");
        });
    }
}