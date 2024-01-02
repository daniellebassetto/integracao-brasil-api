using IntegracaoBrasilApi.Model;

namespace IntegracaoBrasilApi.Service.Interface;

public interface ICepService : IBaseService
{
    Task<CepModel?> Get(string cep);
}