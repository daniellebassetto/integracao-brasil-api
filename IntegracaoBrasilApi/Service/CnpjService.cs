using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class CnpjService(ICnpjRefit refit) : BaseService<ICnpjRefit>(refit), ICnpjService
{
    public async Task<CnpjModel?> Get(string cnpj)
    {
        var response = await _refit.Get(cnpj);
        if (response != null && response.IsSuccessStatusCode)
            return response.Content;
        else
            return null;
    }
}