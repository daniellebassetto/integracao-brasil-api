using IntegracaoBrasilApi.Model;

namespace IntegracaoBrasilApi.Service.Interface;

public interface INcmService : IBaseService
{
    Task<NcmModel?> Get(string code);
}