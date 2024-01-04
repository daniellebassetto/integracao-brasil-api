using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class NcmService(INcmRefit refit) : BaseService<INcmRefit>(refit), INcmService
{
    public async Task<NcmModel?> Get(string code)
    {
        var response = await _refit.Get(code);
        if (response != null && response.IsSuccessStatusCode)
            return response.Content;
        else
            return null;
    }
}