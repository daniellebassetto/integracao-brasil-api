using IntegracaoBrasilApi.Extensions;
using IntegracaoBrasilApi.Service;
using IntegracaoBrasilApi.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICepService, CepService>();
builder.Services.AddScoped<ICnpjService, CnpjService>();

builder.Services.AddIntegrations(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();