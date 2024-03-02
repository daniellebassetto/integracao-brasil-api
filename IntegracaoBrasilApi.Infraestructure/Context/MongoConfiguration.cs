namespace IntegracaoBrasilApi.Infraestructure.Context;

public static class MongoConfiguration
{
    public static string? ConnectionString { get; set; } = string.Empty;
    public static string? Database { get; set; } = string.Empty;
    public static string? ReplicaSet { get; set; } = string.Empty;
}