namespace IntegracaoBrasilApi.Api.Controllers;

public class BaseResponse<T>
{
    public T? Result { get; set; }
}