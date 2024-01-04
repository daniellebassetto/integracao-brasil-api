using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class BaseService<IRefit>(IRefit refit) : IBaseService
    where IRefit : class
{
    protected readonly IRefit _refit = refit;
}