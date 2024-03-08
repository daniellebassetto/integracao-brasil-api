using IntegracaoBrasilApi.ApiClient.RefitInterfaces;
using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Interfaces;

namespace IntegracaoBrasilApi.Domain.Services;

public class LegalPersonRegistrationService(ILegalPersonRegistrationRefit refit) : BaseService_2<ILegalPersonRegistrationRefit>(refit), ILegalPersonRegistrationService
{
    public async Task<BaseResponseApiContent<OutputGetByCnpjLegalPersonRegistration, ApiResponseException>> GetByCnpj(string cnpj)
    {
        var response = await _refit!.GetByCnpj(cnpj);
        return ReturnResponse<OutputGetByCnpjLegalPersonRegistration, ApiResponseException>(response);
    }
}