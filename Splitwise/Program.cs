using Microsoft.EntityFrameworkCore;
using Splitwise;
using Splitwise.Repositories;
using Splitwise.Services;
using Splitwise.Shared;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();