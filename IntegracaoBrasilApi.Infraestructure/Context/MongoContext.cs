using MongoDB.Driver;

namespace IntegracaoBrasilApi.Infraestructure.Context;

public class MongoContext : IMongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext()
    {
        try
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(MongoConfiguration.ConnectionString));

            settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            settings.ReadPreference = ReadPreference.SecondaryPreferred;

            if (!string.IsNullOrEmpty(MongoConfiguration.ReplicaSet))
                settings.ReplicaSetName = MongoConfiguration.ReplicaSet;

            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase(MongoConfiguration.Database);
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possível se conectar com o servidor.", ex);
        }
    }

    public IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>(typeof(T).Name);
}