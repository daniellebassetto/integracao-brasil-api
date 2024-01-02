using IntegracaoBrasilApi.Refit;
using Refit;

namespace IntegracaoBrasilApi.Extensions;

public static class ServiceCollectionExtensions
{
    private const string ConfigViaCepIntegration = "Integrations:ViaCep";
    private const string ConfigBrasilApi = "Integrations:BrasilApi";

    public static IServiceCollection AddIntegrations(this IServiceCollection service, IConfiguration configuration)
    {
        var baseUrlViaCep = configuration[ConfigViaCepIntegration];
        var baseUrlBrasilApi = configuration[ConfigBrasilApi];

        service.AddRefitClient<ICepRefit>().ConfigureHttpClient(c => { c.BaseAddress = new Uri(baseUrlViaCep ?? string.Empty); });
        service.AddRefitClient<ICnpjRefit>().ConfigureHttpClient(c => { c.BaseAddress = new Uri(baseUrlBrasilApi ?? string.Empty); });

        return service;
    }
}