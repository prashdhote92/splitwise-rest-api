using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Splitwise;
using Splitwise.Repositories;
using Splitwise.Services;
using Splitwise.Shared;

void AddSwagger(WebApplicationBuilder builder1)
{
    builder1.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo() {Title = "Splitwise API", Version = "v1"});
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });
}

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
AddSwagger(builder);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
var appSettings = builder.Configuration.Get<AppSettings>();
builder.Services.AddSingleton(appSettings);
AddServices(builder.Services);
AddDbContext(builder.Services);
AddAuthentication(builder);

void AddDbContext(IServiceCollection services)
{
    services.AddDbContext<DataContext>();
}

void AddServices(IServiceCollection serviceCollection)
{
    serviceCollection.AddTransient<IUserRepository, UserRepository>();
    serviceCollection.AddTransient<IExpenseRepository, ExpenseRepository>();
    serviceCollection.AddTransient<IUserService, UserService>();
    serviceCollection.AddTransient<IExpenseService, ExpenseService>();
    serviceCollection.AddDbContext<DataContext>(options => options.UseNpgsql(appSettings.DbConnectionString));
    serviceCollection.AddAutoMapper(x => x.AddProfile<SplitwiseAutoMapperProfile>());
}

void AddAuthentication(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = appSettings.JwtSetting.Issuer,
            ValidAudience = appSettings.JwtSetting.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSetting.Key)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });
    webApplicationBuilder.Services.AddAuthorization();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();