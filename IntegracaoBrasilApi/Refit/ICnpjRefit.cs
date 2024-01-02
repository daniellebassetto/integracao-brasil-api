using IntegracaoBrasilApi.DTOs;
using Refit;

namespace IntegracaoBrasilApi.Refit;

public interface ICnpjRefit
{
    [Get("/api/cnpj/v1/{cnpj}")]
    Task <ApiResponse<CnpjDTO>> Get(string cnpj);
}