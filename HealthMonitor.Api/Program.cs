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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("https://cdnjs.cloudflare.com/ajax/libs/swagger-ui/5.0.0/swagger-ui.min.css");
        c.DocumentTitle = "HealthMonitor API";
        c.HeadContent = @"<style>
            * { box-sizing: border-box; }
            body { background: #09090b !important; margin: 0; }
            .swagger-ui { background: #09090b; font-family: 'Inter', -apple-system, sans-serif; }
            .swagger-ui .topbar { background: #111113; border-bottom: 1px solid #27272a; padding: 10px 0; }
            .swagger-ui .topbar .download-url-wrapper { display: none; }
            .swagger-ui .info { margin: 24px 0 16px; }
            .swagger-ui .info .title { color: #a78bfa; font-size: 28px; font-weight: 700; }
            .swagger-ui .info p, .swagger-ui .info li { color: #71717a; }
            .swagger-ui .scheme-container { background: #111113; border: 1px solid #27272a; border-radius: 10px; padding: 16px; box-shadow: none; }
            .swagger-ui select { background: #18181b; color: #e4e4e7; border: 1px solid #3f3f46; border-radius: 6px; }
            .swagger-ui .btn.authorize { background: #4f46e5; color: #fff; border: none; border-radius: 8px; font-weight: 600; padding: 8px 16px; }
            .swagger-ui .btn.authorize:hover { background: #4338ca; }
            .swagger-ui .btn.authorize svg { fill: #fff; }
            .swagger-ui .opblock-tag { color: #e4e4e7; border-bottom: 1px solid #27272a; font-size: 16px; font-weight: 600; padding: 12px 0; }
            .swagger-ui .opblock-tag:hover { background: #18181b; border-radius: 8px; }
            .swagger-ui .opblock { background: #111113; border: 1px solid #27272a; border-radius: 10px; margin: 6px 0; box-shadow: none; }
            .swagger-ui .opblock.opblock-get { border-left: 3px solid #22c55e; }
            .swagger-ui .opblock.opblock-post { border-left: 3px solid #818cf8; }
            .swagger-ui .opblock.opblock-put { border-left: 3px solid #f59e0b; }
            .swagger-ui .opblock.opblock-delete { border-left: 3px solid #ef4444; }
            .swagger-ui .opblock .opblock-summary { border: none; }
            .swagger-ui .opblock .opblock-summary-method { border-radius: 6px; font-weight: 700; min-width: 70px; text-align: center; }
            .swagger-ui .opblock .opblock-summary-path { color: #d4d4d8; font-weight: 500; }
            .swagger-ui .opblock .opblock-summary-description { color: #71717a; }
            .swagger-ui .opblock-body { background: #09090b; border-top: 1px solid #27272a; }
            .swagger-ui .opblock-description-wrapper p { color: #a1a1aa; }
            .swagger-ui .tab li { color: #71717a; }
            .swagger-ui .tab li.active { color: #a78bfa; border-bottom-color: #a78bfa; }
            .swagger-ui table thead tr td, .swagger-ui table thead tr th { color: #a1a1aa; border-bottom: 1px solid #27272a; font-size: 12px; text-transform: uppercase; letter-spacing: 0.05em; }
            .swagger-ui table tbody tr td { color: #d4d4d8; border-bottom: 1px solid #1c1c1e; }
            .swagger-ui .parameter__name { color: #e4e4e7; font-weight: 600; }
            .swagger-ui .parameter__type { color: #818cf8; }
            .swagger-ui .parameter__deprecated { color: #ef4444; }
            .swagger-ui input[type=text], .swagger-ui input[type=email], .swagger-ui input[type=file], .swagger-ui textarea { background: #18181b; color: #e4e4e7; border: 1px solid #3f3f46; border-radius: 8px; padding: 8px 12px; }
            .swagger-ui input[type=text]:focus, .swagger-ui textarea:focus { border-color: #818cf8; outline: none; box-shadow: 0 0 0 3px rgba(129,140,248,0.15); }
            .swagger-ui .btn { border-radius: 8px; font-weight: 600; transition: all 0.2s; }
            .swagger-ui .btn.execute { background: #4f46e5; border-color: #4f46e5; color: #fff; }
            .swagger-ui .btn.execute:hover { background: #4338ca; }
            .swagger-ui .btn.cancel { background: transparent; border: 1px solid #3f3f46; color: #a1a1aa; }
            .swagger-ui .responses-inner { background: #09090b; }
            .swagger-ui .response-col_status { color: #22c55e; font-weight: 700; }
            .swagger-ui .response-col_links { color: #818cf8; }
            .swagger-ui .highlight-code { background: #18181b !important; border-radius: 8px; }
            .swagger-ui .highlight-code code { color: #a78bfa; }
            .swagger-ui section.models { background: #111113; border: 1px solid #27272a; border-radius: 10px; }
            .swagger-ui section.models h4 { color: #e4e4e7; }
            .swagger-ui .model-box { background: #18181b; border-radius: 6px; }
            .swagger-ui .model { color: #a1a1aa; }
            .swagger-ui .prop-type { color: #818cf8; }
            .swagger-ui .prop-format { color: #71717a; }
            .swagger-ui .dialog-ux .modal-ux { background: #111113; border: 1px solid #27272a; border-radius: 14px; box-shadow: 0 25px 50px rgba(0,0,0,0.7); }
            .swagger-ui .dialog-ux .modal-ux-header { background: #18181b; border-bottom: 1px solid #27272a; border-radius: 14px 14px 0 0; padding: 16px 20px; }
            .swagger-ui .dialog-ux .modal-ux-header h3 { color: #e4e4e7; font-weight: 700; margin: 0; }
            .swagger-ui .dialog-ux .modal-ux-header button { color: #71717a; }
            .swagger-ui .dialog-ux .modal-ux-content { padding: 20px; }
            .swagger-ui .dialog-ux .modal-ux-content p, .swagger-ui .dialog-ux .modal-ux-content h4 { color: #a1a1aa; }
            .swagger-ui .dialog-ux .modal-ux-content label { color: #e4e4e7; font-weight: 600; }
            .swagger-ui .auth-container { border-color: #27272a; }
            .swagger-ui .scopes h2 { color: #a1a1aa; }
            .swagger-ui .markdown p, .swagger-ui .markdown pre { color: #a1a1aa; }
            .swagger-ui .loading-container .loading:after { border-color: #818cf8 transparent; }
        </style>";
    });
}

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// app.UseHttpsRedirection();

//lista de exercitii predefinite
DbInitializer.SeedExercises();

app.Run();