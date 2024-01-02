using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class CepService(ICepRefit viaCepRefit) : ICepService
{
    private readonly ICepRefit _viaCepRefit = viaCepRefit;

    public async Task<CepModel?> GetCep(string cep)
    {
        var response = await _viaCepRefit.GetCep(cep);
        if (response != null && response.IsSuccessStatusCode)
            return response.Content;
        else
            return null;
    }
}