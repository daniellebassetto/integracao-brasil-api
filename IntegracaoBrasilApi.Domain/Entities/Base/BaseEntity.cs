using IntegracaoBrasilApi.Domain.ApiManagement;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace IntegracaoBrasilApi.Domain.Entities;

public class BaseEntity<TEntity> : BaseSetProperty<TEntity>
    where TEntity : BaseEntity<TEntity>
{
    [JsonIgnore]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string Id { get; private set; } = ObjectId.GenerateNewId().ToString();

    [JsonIgnore]
    [BsonElement("data_criacao")]
    public virtual DateTime CreationDate { get; set; }

    [JsonIgnore]
    [BsonElement("data_alteracao")]
    public virtual DateTime? ChangeDate { get; set; }

    public TEntity? SetCreateData()
    {
        CreationDate = DateTime.Now;

        return this as TEntity;
    }

    public TEntity? SetUpdateData()
    {
        ChangeDate = DateTime.Now;

        return this as TEntity;
    }
}

public class BaseEntity_0 : BaseEntity<BaseEntity_0> { }