using IntegracaoBrasilApi.DTOs;
using Refit;

namespace IntegracaoBrasilApi.Refit;

public interface ICepRefit
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<CepDTO>> Get(string cep);
}