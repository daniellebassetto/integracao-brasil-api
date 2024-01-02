using IntegracaoBrasilApi.Model;

namespace IntegracaoBrasilApi.Service.Interface;

public interface ICnpjService
{
    Task<CnpjModel?> GetCnpj(string cnpj);
}