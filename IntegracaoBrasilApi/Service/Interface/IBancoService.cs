using IntegracaoBrasilApi.Model;

namespace IntegracaoBrasilApi.Service.Interface;

public interface IBancoService
{
    Task<List<BancoModel>?> Get();
}