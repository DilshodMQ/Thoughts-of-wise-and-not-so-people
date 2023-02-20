using DsrProject.Api;
using DsrProject.Api.Configuration;
using DsrProject.Services.Settings;
using DsrProject.Settings;

var builder = WebApplication.CreateBuilder(args);

var mainSettings = Settings.Load<MainSettings>("Main");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
builder.AddAppLogger();

var services=builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors();

services.AddAppHealthChecks();
services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings);
services.AddAppControllerAndViews();

services.RegisterAppServices();



var app = builder.Build();

app.UseAppHealthChecks();
app.UseAppSwagger();

// Configure the HTTP request pipeline.

app.UseAppControllerAndViews();

app.Run();
