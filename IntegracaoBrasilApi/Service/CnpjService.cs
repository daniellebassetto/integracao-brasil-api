using AutoMapper;
using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class CnpjService(IMapper mapper, ICnpjRefit cnpjRefit) : ICnpjService
{
    private readonly ICnpjRefit _cnpjRefit = cnpjRefit;
    private readonly IMapper _mapper = mapper;   

    public async Task<CnpjModel?> Get(string cnpj)
    {
        var response = await _cnpjRefit.Get(cnpj);
        if (response != null && response.IsSuccessStatusCode)
            return _mapper.Map<CnpjModel>(response.Content);
        else
            return null;
    }
}