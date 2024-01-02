using AutoMapper;
using IntegracaoBrasilApi.DTOs;
using IntegracaoBrasilApi.Model;

namespace IntegracaoBrasilApi.Mapping;

public class DTOToModelMap : Profile
{
    public DTOToModelMap()
    {
        CreateMap<BancoDTO, BancoModel>().ReverseMap();
        CreateMap<CnpjDTO, CnpjModel>().ReverseMap();
        CreateMap<CepDTO, CepModel>().ReverseMap();
        CreateMap<FeriadoDTO, FeriadoModel>().ReverseMap();
        CreateMap<NcmDTO, NcmModel>().ReverseMap();
    }    
}