using IntegracaoBrasilApi.Model;
using Refit;

namespace IntegracaoBrasilApi.Refit;

public interface INcmRefit
{
    [Get("/api/ncm/v1/{code}")]
    Task<ApiResponse<NcmModel>> Get(string code);
}