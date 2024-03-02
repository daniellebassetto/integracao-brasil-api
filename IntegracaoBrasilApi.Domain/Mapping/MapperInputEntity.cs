using AutoMapper;
using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Entities;

namespace IntegracaoBrasilApi.Domain.Mapping;

public class MapperInputEntity : Profile
{
    public MapperInputEntity()
    {
        #region User
        CreateMap<InputCreateUser, User>().ReverseMap();
        CreateMap<InputUpdateUser, User>().ReverseMap();
        #endregion
    }
}