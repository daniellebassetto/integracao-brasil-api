using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace IntegracaoBrasilApi.Infraestructure.Map.Base;

public static class BaseMap
{
    public static BsonMemberMap ObjectId(this BsonMemberMap bsonSerializer)
    {
        bsonSerializer.SetSerializer(new StringSerializer(BsonType.ObjectId));
        return bsonSerializer;
    }

    public static BsonMemberMap IsRequired(this BsonMemberMap bsonSerializer)
    {
        bsonSerializer.SetIsRequired(true);
        return bsonSerializer;
    }
}