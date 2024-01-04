using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class BancoService(IBancoRefit refit) : BaseService<IBancoRefit>(refit), IBancoService
{
    public async Task<List<BancoModel>?> GetAll()
    {
        var response = await _refit.GetAll();
        if (response != null && response.IsSuccessStatusCode)
            return response.Content;
        else
            return null;
    }
}