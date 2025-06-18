using System.Text.Json.Serialization;
using dotenv.net;
using Skills.API.Pipeline.Cors;
using Skills.API.Pipeline.Filters;
using Skills.API.Pipeline.Handlers;
using Skills.API.Pipeline.Middlewares;
using Skills.API.Services;
using Skills.Application;
using Skills.Domain.Contracts;
using Skills.Persistence;
using Skills.Persistence.Context;
using Skills.Persistence.Seeding;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// LAYERS CONFIG
builder.Services.ConfigurePersistence();
builder.Services.ConfigureApplication();

// CORS
builder.Services.ConfigureCorsPolicy();

// CONTROLLERS AND OPTIONS
builder.Services.AddControllers(op =>
{
    op.Filters.Add<AuthorizationFilter>();
}).AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SERVICES INJECTION
builder.Services.AddScoped<IAuthenticator, AuthenticationService>();
builder.Services.AddScoped<IPasswordEncrypter, PasswordEncrypterService>();


var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<SkillsContext>()
    ?? throw new InvalidOperationException("Failed to resolve SkillsContext from service provider.");
dataContext.Database.EnsureCreated();
await dataContext.SeedData();

app.UseMiddleware<AuthenticationMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseErrorHandler();
app.MapControllers();
app.Run();
