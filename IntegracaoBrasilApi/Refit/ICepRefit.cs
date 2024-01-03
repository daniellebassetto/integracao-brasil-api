using IntegracaoBrasilApi.Model;
using Refit;

namespace IntegracaoBrasilApi.Refit;

public interface ICepRefit
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<CepModel>> Get(string cep);
}