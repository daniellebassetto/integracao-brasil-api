namespace IntegracaoBrasilApi.Arguments;

public class BaseInputIdentityUpdate<TInputUpdate>(string? id, TInputUpdate? inputUpdate)
{
    public string? Id { get; private set; } = id;
    public TInputUpdate? InputUpdate { get; private set; } = inputUpdate;
}

public class BaseInputIdentityUpdate_0 : BaseInputIdentityUpdate<object>
{
    public BaseInputIdentityUpdate_0() : base(default, default) { }
}