using AutoMapper;
using IntegracaoBrasilApi.Domain.ApiManagement;

namespace IntegracaoBrasilApi.Domain.Mapping;

public class Mapper(IMapper mapperEntityOutput, IMapper mapperInputEntity) : BaseSetProperty<Mapper>
{
    public IMapper MapperEntityOutput { get; private set; } = mapperEntityOutput;
    public IMapper MapperInputEntity { get; private set; } = mapperInputEntity;
}