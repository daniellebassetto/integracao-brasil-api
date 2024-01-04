using AutoMapper;
using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class BancoService(IMapper mapper, IBancoRefit refit) : BaseService<IBancoRefit>(mapper, refit), IBancoService
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