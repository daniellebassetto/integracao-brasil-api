using IntegracaoBrasilApi.Model;
using Refit;

namespace IntegracaoBrasilApi.Refit;

public interface IFeriadoRefit
{
    [Get("/api/feriados/v1/{ano}")]
    Task <ApiResponse<List<FeriadoModel>>> Get(int ano);
}