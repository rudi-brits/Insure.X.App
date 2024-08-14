using Insure.X.Api.Utilities;
using Insure.X.Client.Interfaces;
using Insure.X.Client.Repository;
using Insure.X.Client.Services;
using Insure.X.Domain.Interfaces;
using Insure.X.Domain.Serialization;
using Insure.X.Domain.Services;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Repository;
using Insure.X.Investment.Services;
using Insure.X.Resource.Database.Data;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

/// <summary>
/// Program sets up all the API goodies
/// </summary>
/// 
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddSingleton<InsureXDatabase>();

builder.Services.AddSingleton<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<IClientService, ClientService>();

builder.Services.AddSingleton<IInvestmentRepository, InvestmentRepository>();
builder.Services.AddSingleton<IInvestmentService, InvestmentService>();
builder.Services.AddSingleton<IInvestmentCalculationService, InvestmentCalculationService>();

builder.Services.AddSingleton<ILogService, LogService>();

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(
        new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DecimalJsonConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();

app.Run();
