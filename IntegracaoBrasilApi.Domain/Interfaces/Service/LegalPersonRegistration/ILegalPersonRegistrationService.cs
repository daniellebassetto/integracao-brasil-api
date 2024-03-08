using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Interfaces.Service;
using IntegracaoBrasilApi.Domain.Services;

namespace IntegracaoBrasilApi.Domain.Interfaces;

public interface ILegalPersonRegistrationService : IBaseService_0
{
    Task<BaseResponseApiContent<OutputGetByCnpjLegalPersonRegistration, ApiResponseException>> GetByCnpj(string cnpj);
}