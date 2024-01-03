using AutoMapper;
using IntegracaoBrasilApi.Model;

namespace IntegracaoBrasilApi.Mapping;

public class DTOToModelMap : Profile
{
    public DTOToModelMap()
    {
        CreateMap<BancoModel, BancoModel>().ReverseMap();
        CreateMap<CnpjModel, CnpjModel>().ReverseMap();
        CreateMap<CepModel, CepModel>().ReverseMap();
        CreateMap<FeriadoModel, FeriadoModel>().ReverseMap();
        CreateMap<NcmModel, NcmModel>().ReverseMap();
    }    
}