using Refit;

namespace IntegracaoBrasilApi.ApiClient.RefitInterfaces;

public interface IAddressRefit
{
    [Get("/api/cep/v1/{cep}")]
    Task<ApiResponse<string>> GetByCep(string cep);
}