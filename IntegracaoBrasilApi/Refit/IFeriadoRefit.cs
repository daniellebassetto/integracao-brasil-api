using IntegracaoBrasilApi.DTOs;
using Refit;

namespace IntegracaoBrasilApi.Refit;

public interface IFeriadoRefit
{
    [Get("/api/feriados/v1/{ano}")]
    Task <ApiResponse<List<FeriadoDTO>>> Get(int ano);
}