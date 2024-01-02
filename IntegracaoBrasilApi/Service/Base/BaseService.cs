using AutoMapper;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class BaseService<IRefit>(IMapper mapper, IRefit refit) : IBaseService
    where IRefit : class
{
    protected readonly IMapper _mapper = mapper;
    protected readonly IRefit _refit = refit;
}