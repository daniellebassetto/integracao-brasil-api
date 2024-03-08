using IntegracaoBrasilApi.Domain.Services;

namespace IntegracaoBrasilApi.Api.Controllers;

public class BaseResponseApi<TTypeResult, TTypeException>
{
    public BaseResponseApiContent<TTypeResult, TTypeException>? Value { get; set; }
}