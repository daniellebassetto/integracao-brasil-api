using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class CepService(ICepRefit refit) : BaseService<ICepRefit>(refit), ICepService
{
    public async Task<CepModel?> Get(string cep)
    {
        var response = await _refit.Get(cep);
        if (response != null && response.IsSuccessStatusCode)
            return response.Content;
        else
            return null;
    }
}