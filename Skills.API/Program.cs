using System.Text.Json.Serialization;
using dotenv.net;
using Skills.API.Pipeline.Cors;
using Skills.API.Pipeline.Handlers;
using Skills.API.Pipeline.Middlewares;
using Skills.Application;
using Skills.Infrastructure.Identity;
using Skills.Infrastructure.Persistence;
using Skills.Infrastructure.Persistence.Context;
using Skills.Infrastructure.Persistence.Seeding;

DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../.env"]));

var builder = WebApplication.CreateBuilder(args);

// LAYERS CONFIG
builder.Services.ConfigureApplication();
builder.Services.ConfigurePersistence();
builder.Services.ConfigureIdentity();

// CORS
builder.Services.ConfigureCorsPolicy();

// CONTROLLERS AND OPTIONS
builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<SkillsContext>()
    ?? throw new InvalidOperationException("Failed to resolve SkillsContext from service provider.");

dataContext.Database.EnsureCreated();
await dataContext.SeedData();

app.UseMiddleware<SessionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseErrorHandler();
app.MapControllers();
app.Run();
