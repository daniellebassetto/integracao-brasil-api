using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Services;

namespace IntegracaoBrasilApi.Domain.Interfaces.Service;

public interface IBaseService<TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput, TInputIdentifier>
    where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
{
    IReadOnlyCollection<Notification> ListNotification { get; }
    List<TOutput> GetAll();
    TOutput Get(string id);
    List<TOutput> GetListByListId(List<string> listId);
    TOutput GetByIdentifier(TInputIdentifier inputIdentifier);
    List<TOutput> GetListByListIdentifier(List<TInputIdentifier> listInputIdentifier);
    string? Create(TInputCreate entity);
    List<string>? Create(List<TInputCreate> listEntity);
    string? Update(TInputIdentityUpdate inputIdentityUpdate);
    List<string>? Update(List<TInputIdentityUpdate> listInputIdentityUpdate);
    bool? Delete(string id);
    List<bool>? Delete(List<string> listId);
}

#region AllParameters
public interface IBaseService_0 : IBaseService<object, object, BaseInputIdentityUpdate_0, object, object> { }
#endregion