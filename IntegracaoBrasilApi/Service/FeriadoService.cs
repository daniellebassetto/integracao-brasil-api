using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Service;

public class FeriadoService(IFeriadoRefit refit) : BaseService<IFeriadoRefit>(refit), IFeriadoService
{
    [HttpGet("{ano}")]
    public async Task<List<FeriadoModel>?> Get(int ano)
    {
        var response = await _refit.Get(ano);
        if (response != null && response.IsSuccessStatusCode)
            return response.Content;
        else
            return null;
    }
}