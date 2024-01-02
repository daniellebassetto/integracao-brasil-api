using IntegracaoBrasilApi.Model;

namespace IntegracaoBrasilApi.Service.Interface;

public interface IBancoService : IBaseService
{
    Task<List<BancoModel>?> GetAll();
}