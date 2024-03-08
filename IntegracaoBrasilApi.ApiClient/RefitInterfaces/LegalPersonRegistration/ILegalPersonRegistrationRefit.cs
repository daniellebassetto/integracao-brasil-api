using Refit;

namespace IntegracaoBrasilApi.ApiClient.RefitInterfaces;

public interface ILegalPersonRegistrationRefit
{
    [Get("/api/cnpj/v1/{cnpj}")]
    Task<ApiResponse<string>> GetByCnpj(string cnpj);
}