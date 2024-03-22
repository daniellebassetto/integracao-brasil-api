using Refit;

namespace IntegracaoBrasilApi.ApiClient.RefitInterfaces;

public interface IAddressRefit
{
    [Get("/api/cep/v1/{postalCode}")]
    Task<ApiResponse<string>> GetByPostalCode(string postalCode);
}