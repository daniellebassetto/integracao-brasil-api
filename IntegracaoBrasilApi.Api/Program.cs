using AutoMapper;
using IntegracaoBrasilApi.Api.DependencyInjection;
using IntegracaoBrasilApi.Api.Extensions;
using IntegracaoBrasilApi.Domain.ApiManagement;
using IntegracaoBrasilApi.Domain.Mapping;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BrasilApi", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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