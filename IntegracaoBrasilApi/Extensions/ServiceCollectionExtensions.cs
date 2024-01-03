using IntegracaoBrasilApi.Refit;
using IntegracaoBrasilApi.Service.Interface;
using IntegracaoBrasilApi.Service;
using Refit;
using IntegracaoBrasilApi.Mapping;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Extensions;

public static class ServiceCollectionExtensions
{
    private const string ConfigViaCepIntegration = "Integrations:ViaCep";
    private const string ConfigBrasilApi = "Integrations:BrasilApi";

    public static IServiceCollection ConfigureServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<ICepService, CepService>();
        service.AddScoped<ICnpjService, CnpjService>();
        service.AddScoped<IBancoService, BancoService>();
        service.AddScoped<IFeriadoService, FeriadoService>();
        service.AddScoped<INcmService, NcmService>();
               
        #region Refit
        var baseUrlViaCep = configuration[ConfigViaCepIntegration];
        var baseUrlBrasilApi = configuration[ConfigBrasilApi];

        var refitSettings = new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
            })
        };

        service.AddRefitClient<ICepRefit>(refitSettings).ConfigureHttpClient(c => { c.BaseAddress = new Uri(baseUrlViaCep ?? string.Empty); });
        service.AddRefitClient<ICnpjRefit>(refitSettings).ConfigureHttpClient(c => { c.BaseAddress = new Uri(baseUrlBrasilApi ?? string.Empty); });
        service.AddRefitClient<IBancoRefit>(refitSettings).ConfigureHttpClient(c => { c.BaseAddress = new Uri(baseUrlBrasilApi ?? string.Empty); });
        service.AddRefitClient<IFeriadoRefit>(refitSettings).ConfigureHttpClient(c => { c.BaseAddress = new Uri(baseUrlBrasilApi ?? string.Empty); });
        service.AddRefitClient<INcmRefit>(refitSettings).ConfigureHttpClient(c => { c.BaseAddress = new Uri(baseUrlBrasilApi ?? string.Empty); });
        #endregion

        service.AddAutoMapper(typeof(DTOToModelMap));

        return service;
    }
}