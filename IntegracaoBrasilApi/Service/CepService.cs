﻿using AutoMapper;
using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;

namespace IntegracaoBrasilApi.Service;

public class CepService(IMapper mapper, ICepRefit cepRefit) : ICepService
{
    private readonly ICepRefit _cepRefit = cepRefit;
    private readonly IMapper _mapper = mapper;

    public async Task<CepModel?> Get(string cep)
    {
        var response = await _cepRefit.Get(cep);
        if (response != null && response.IsSuccessStatusCode)
            return _mapper.Map<CepModel>(response.Content);
        else
            return null;
    }
}