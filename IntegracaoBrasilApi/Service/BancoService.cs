using AutoMapper;
using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class BancoService(IMapper mapper, IBancoRefit bancoRefit) : IBancoService
{
    private readonly IBancoRefit _bancoRefit = bancoRefit;
    private readonly IMapper _mapper = mapper;

    public async Task<List<BancoModel>?> Get()
    {
        var response = await _bancoRefit.Get();
        if (response != null && response.IsSuccessStatusCode)
            return _mapper.Map<List<BancoModel>>(response.Content);
        else
            return null;
    }
}