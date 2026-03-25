using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IUsdaFoodLogic, UsdaFoodLogic>();

//AddScoped
//AddTransient
//AddSingleton
//AddDbContext

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();