using AutoMapper;
using IntegracaoBrasilApi.Api.DependencyInjection;
using IntegracaoBrasilApi.Api.Extensions;
using IntegracaoBrasilApi.Domain.ApiManagement;
using IntegracaoBrasilApi.Domain.Mapping;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.SeedMongoConfiguration();

builder.Services.AddCors(c => { c.AddPolicy("CorsPolicy", options => { options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }); });

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.Formatting = Formatting.Indented;
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DateFormatString = "dd/MM/yyyy";
    options.SerializerSettings.ContractResolver = new IgnoreJsonPropertyContractResolver();
});

builder.Services.ConfigureDependencyInjection(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configure = new MapperConfiguration(config =>
{
    config.AddProfile(new MapperGeneric<string, string>());
});
IMapper mapper = configure.CreateMapper();
builder.Services.AddSingleton(mapper);

#region ApiData
ApiData.SetMapper(new IntegracaoBrasilApi.Domain.Mapping.Mapper(new MapperConfiguration(config => { config.AddProfile(new MapperEntityOutput()); }).CreateMapper(), new MapperConfiguration(config => { config.AddProfile(new MapperInputEntity()); }).CreateMapper()));
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/pt-br/swagger.json", "BrasilApi");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors(builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

app.MapControllers();

app.Run();
