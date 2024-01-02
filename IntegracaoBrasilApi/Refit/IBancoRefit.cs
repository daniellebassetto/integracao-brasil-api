using IntegracaoBrasilApi.DTOs;
using Refit;

namespace IntegracaoBrasilApi.Refit;

public interface IBancoRefit
{
    [Get("/api/banks/v1")]
    Task<ApiResponse<List<BancoDTO>>> Get();
}