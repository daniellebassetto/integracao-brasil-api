using IntegracaoBrasilApi.Model;
using Refit;

namespace IntegracaoBrasilApi.Refit;

public interface ICnpjRefit
{
    [Get("/api/cnpj/v1/{cnpj}")]
    Task <ApiResponse<CnpjModel>> Get(string cnpj);
}