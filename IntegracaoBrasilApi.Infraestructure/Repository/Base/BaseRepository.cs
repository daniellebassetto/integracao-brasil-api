using IntegracaoBrasilApi.Domain.Entities;
using IntegracaoBrasilApi.Domain.Interfaces.Repository;
using IntegracaoBrasilApi.Infraestructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IntegracaoBrasilApi.Infraestructure.Repository;

public class BaseRepository<TEntity, TInputIdentifier> : IBaseRepository<TEntity, TInputIdentifier>
    where TEntity : BaseEntity<TEntity>
{
    protected readonly IMongoContext _context;
    protected readonly IMongoCollection<TEntity> _collection;

    public BaseRepository(IMongoContext context)
    {
        _context = context;
        _collection = _context.GetCollection<TEntity>();
    }

    #region Read
    public List<TEntity> GetAll()
    {
        return [.. _collection.AsQueryable()];
    }

    public List<TEntity> GetListByListId(List<string> listId)
    {
        return _collection.Find(p => listId.Contains(p.Id)).ToList();
    }

    public TEntity? GetByIdentifier(TInputIdentifier inputIdentifier)
    {
        return GetListByListIdentifier([inputIdentifier]).FirstOrDefault();
    }

    public List<TEntity> GetListByListIdentifier(List<TInputIdentifier> listIdentifier)
    {
        var filterBuilder = Builders<TEntity>.Filter;
        var filter = Builders<TEntity>.Filter.Empty;

        foreach (var identifier in listIdentifier)
        {
            foreach (var property in typeof(TInputIdentifier).GetProperties())
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(identifier);

                if (propertyName.Contains("Id"))
                    propertyValue = new ObjectId(propertyValue?.ToString());

                if (propertyValue != null)
                    filter &= filterBuilder.Eq(propertyName, propertyValue);
            }
        }
        return _collection.Find(filter).ToList();
    }
    #endregion

    #region Create
    public List<string> Create(List<TEntity> listEntity)
    {
        _collection.InsertMany((from i in listEntity select i.SetCreateData()).ToList());
        return (from i in listEntity select i.Id.ToString()).ToList();
    }
    #endregion

    #region Update
    public List<string> Update(List<TEntity> listEntity)
    {
        var listid = new List<string>();
        foreach (var entity in listEntity)
        {
            _collection.ReplaceOne(p => p.Id == entity.Id, entity.SetUpdateData());
            listid.Add(entity.Id.ToString());
        }
        return listid;
    }
    #endregion

    #region Delete
    public List<bool> Delete(List<string> listId)
    {
        List<bool> listReturn = [];
        foreach (var id in listId)
        {
            listReturn.Add(_collection.DeleteOne(p => p.Id.ToString() == id).DeletedCount > 0);
        }
        return listReturn;
    }
    #endregion
}

#region AllParameters
public class BaseRepository_0(IMongoContext context) : BaseRepository<BaseEntity_0, object>(context) { }
#endregion