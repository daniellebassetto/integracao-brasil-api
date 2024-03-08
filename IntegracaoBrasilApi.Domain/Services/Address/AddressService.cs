using IntegracaoBrasilApi.ApiClient.RefitInterfaces;
using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Interfaces.Service;

namespace IntegracaoBrasilApi.Domain.Services;

public class AddressService(IAddressRefit refit) : BaseService_2<IAddressRefit>(refit), IAddressService
{
    public async Task<BaseResponseApiContent<OutputGetByCepAddress, ApiResponseException>> GetByCep(string cep)
    {
        var response = await _refit!.GetByCep(cep);
        return ReturnResponse<OutputGetByCepAddress, ApiResponseException>(response);
    }
}