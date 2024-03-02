using AutoMapper;
using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Entities;

namespace IntegracaoBrasilApi.Domain.Mapping;

public class MapperEntityOutput : Profile
{
    public MapperEntityOutput()
    {
        #region User
        CreateMap<User, OutputUser>().ReverseMap();
        #endregion
    }
}