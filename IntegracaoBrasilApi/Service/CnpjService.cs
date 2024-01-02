using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class CnpjService(ICnpjRefit cnpjRefit) : ICnpjService
{
    private readonly ICnpjRefit _cnpjRefit = cnpjRefit;

    public async Task<CnpjModel?> GetCnpj(string cnpj)
    {
        var response = await _cnpjRefit.GetCnpj(cnpj);
        if (response != null && response.IsSuccessStatusCode)
            return response.Content;
        else
            return null;
    }
}