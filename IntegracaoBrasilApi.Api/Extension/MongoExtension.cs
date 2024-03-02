using IntegracaoBrasilApi.Infraestructure.Context;

namespace IntegracaoBrasilApi.Api.Extensions;

public static class MongoExtension
{
    public static void SeedMongoConfiguration(this WebApplicationBuilder builder)
    {
        MongoConfiguration.ConnectionString = builder.Configuration["MongoConfiguration:ConnectionString"] ?? "";
        MongoConfiguration.Database = builder.Configuration["MongoConfiguration:Database"] ?? "";
        MongoConfiguration.ReplicaSet = builder.Configuration["MongoConfiguration:ReplicaSet"] ?? "";
    }
}