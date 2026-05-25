using HealthMonitor.BusinessLayer.Core;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.DataAccesLayer.Context;
using Microsoft.EntityFrameworkCore;
using HealthMonitor.DataAccesLayer.Seeding;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Introdu: Bearer {token}",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddHttpClient<IUsdaFoodLogic, UsdaFoodLogic>();
//builder.Services.AddScoped<IFoodLogLogic, FoodLogLogic>();

//AddScoped
//AddTransient
//AddSingleton
//AddDbContext

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("AlabalaPortocalaCineMi_aFuratBanana")
            )
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Auto-repair DB schema mismatch on startup
try
{
    using (var context = new HealthMonitor.DataAccesLayer.Context.AppDbContext())
    {
        var conn = context.Database.GetDbConnection();
        var opened = false;
        if (conn.State != System.Data.ConnectionState.Open)
        {
            conn.Open();
            opened = true;
        }
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "SELECT data_type FROM information_schema.columns WHERE table_name = 'Workouts' AND column_name = 'UserId';";
            var type = cmd.ExecuteScalar()?.ToString();
            Console.WriteLine($"[DB Repair] Current Workouts.UserId data_type: {type}");
            if (type == "character varying" || type == "varchar")
            {
                Console.WriteLine("[DB Repair] Column is varchar/character varying. Converting to integer...");
                using (var cmdAlter = conn.CreateCommand())
                {
                    cmdAlter.CommandText = @"
                        DELETE FROM ""WorkoutExercises"";
                        DELETE FROM ""Workouts"";
                        ALTER TABLE ""Workouts"" ALTER COLUMN ""UserId"" TYPE integer USING ""UserId""::integer;
                    ";
                    cmdAlter.ExecuteNonQuery();
                }
                Console.WriteLine("[DB Repair] Column successfully converted to integer!");
            }
        }
        if (opened) conn.Close();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"[DB Repair Error] {ex.Message}");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// app.UseHttpsRedirection();

//lista de exercitii predefinite
DbInitializer.SeedExercises();

app.Run();