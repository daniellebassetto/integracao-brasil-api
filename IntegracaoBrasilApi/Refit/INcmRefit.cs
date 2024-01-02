using IntegracaoBrasilApi.DTOs;
using Refit;

namespace IntegracaoBrasilApi.Refit;

public interface INcmRefit
{
    [Get("/api/ncm/v1/{code}")]
    Task<ApiResponse<NcmDTO>> Get(string code);
}