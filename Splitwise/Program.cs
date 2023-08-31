using Splitwise;
using Splitwise.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var appSettings = new AppSettings();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
builder.Configuration.Bind(appSettings);
builder.Services.AddSingleton(appSettings);
AddServices(builder.Services);

void AddServices(IServiceCollection serviceCollection)
{
    serviceCollection.AddSingleton<IUserRepository, UserRepository>();
    serviceCollection.AddSingleton<IExpenseRepository, ExpenseRepository>();
    serviceCollection.AddTransient<IUserService, UserService>();
    serviceCollection.AddTransient<IExpenseService, ExpenseService>();
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