using IntegracaoBrasilApi.Model;

namespace IntegracaoBrasilApi.Service.Interface;

public interface IFeriadoService : IBaseService
{
    Task<List<FeriadoModel>?> Get(int ano);
}