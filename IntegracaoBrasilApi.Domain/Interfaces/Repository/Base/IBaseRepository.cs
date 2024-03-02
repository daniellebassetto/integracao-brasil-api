using IntegracaoBrasilApi.Domain.Entities;

namespace IntegracaoBrasilApi.Domain.Interfaces.Repository;

public interface IBaseRepository<TEntity, TInputIdentifier>
    where TEntity : BaseEntity<TEntity>
{
    List<TEntity> GetAll();
    List<TEntity> GetListByListId(List<string> listId);
    TEntity? GetByIdentifier(TInputIdentifier inputIdentifier);
    List<TEntity> GetListByListIdentifier(List<TInputIdentifier> listIdentifier);
    List<string> Create(List<TEntity> listEntity);
    List<string> Update(List<TEntity> listEntity);
    List<bool> Delete(List<string> id);
}

#region All Parameters 
public interface IBaseRepository_0 : IBaseRepository<BaseEntity_0, object> { }
#endregion