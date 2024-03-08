using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Services;

namespace IntegracaoBrasilApi.Domain.Interfaces.Service;

public interface IAddressService : IBaseService_0
{
    Task<BaseResponseApiContent<OutputGetByCepAddress, ApiResponseException>> GetByCep(string cep);
}