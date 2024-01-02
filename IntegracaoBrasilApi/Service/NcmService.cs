using AutoMapper;
using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class NcmService(IMapper mapper, INcmRefit refit) : BaseService<INcmRefit>(mapper, refit), INcmService
{
    public async Task<NcmModel?> Get(string code)
    {
        var response = await _refit.Get(code);
        if (response != null && response.IsSuccessStatusCode)
            return _mapper.Map<NcmModel>(response.Content);
        else
            return null;
    }
}