using MongoDB.Driver;

namespace IntegracaoBrasilApi.Infraestructure.Context;

public interface IMongoContext
{
    IMongoCollection<T> GetCollection<T>();
}