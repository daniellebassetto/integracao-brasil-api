namespace IntegracaoBrasilApi.Model;

public class NcmModel(string? codigo, string? descricao, DateTime dataInicio, DateTime dataFim, string? tipoAto, string? numeroAto, int anoAto)
{
    public string? Codigo { get; private set; } = codigo;
    public string? Descricao { get; private set; } = descricao;
    public DateTime DataInicio { get; private set; } = dataInicio;
    public DateTime DataFim { get; private set; } = dataFim;
    public string? TipoAto { get; private set; } = tipoAto;
    public string? NumeroAto { get; private set; } = numeroAto;
    public int AnoAto { get; private set; } = anoAto;
}