using IntegracaoBrasilApi.Model;

namespace IntegracaoBrasilApi.Service.Interface;

public interface IFeriadoService
{
    Task<List<FeriadoModel>?> Get(int ano);
}