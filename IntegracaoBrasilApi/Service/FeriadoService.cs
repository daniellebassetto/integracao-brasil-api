using AutoMapper;
using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Service;

public class FeriadoService(IFeriadoRefit feriadoRefit, IMapper mapper) : IFeriadoService
{
    private readonly IFeriadoRefit _feriadoRefit = feriadoRefit;
    private readonly IMapper _mapper = mapper;

    [HttpGet("{ano}")]
    public async Task<List<FeriadoModel>?> Get(int ano)
    {
        var response = await _feriadoRefit.Get(ano);
        if (response != null && response.IsSuccessStatusCode)
            return _mapper.Map<List<FeriadoModel>>(response.Content);
        else
            return null;
    }
}