using IntegracaoBrasilApi.ApiClient.RefitInterfaces;
using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Interfaces.Service;

namespace IntegracaoBrasilApi.Domain.Services;

public class AddressService(IAddressRefit refit) : BaseService_2<IAddressRefit>(refit), IAddressService
{
    public async Task<BaseResponseApiContent<OutputGetByPostalCodeAddress, ApiResponseException>> GetByPostalCode(string cep)
    {
        var response = await _refit!.GetByPostalCode(cep);
        return ReturnResponse<OutputGetByPostalCodeAddress, ApiResponseException>(response);
    }
}