using Insure.X.Client.Interfaces;
using Insure.X.Client.Repository;
using Insure.X.Client.Services;
using Insure.X.Domain.Serialization;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Repository;
using Insure.X.Investment.Services;
using Insure.X.Resource.Database.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InsureXDatabase>();

builder.Services.AddSingleton<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<IClientService, ClientService>();

builder.Services.AddSingleton<IInvestmentRepository, InvestmentRepository>();
builder.Services.AddSingleton<IInvestmentService, InvestmentService>();

builder.Services.AddControllers()
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
app.UseAuthorization();
app.MapControllers();

app.Run();
