using DsrProject.Api;
using DsrProject.Api.Configuration;
using DsrProject.Context;
using DsrProject.Services.Settings;
using DsrProject.Settings;
using DsrProject.Context;

var builder = WebApplication.CreateBuilder(args);

var mainSettings = Settings.Load<MainSettings>("Main");
var identitySettings = Settings.Load<IdentitySettings>("Identity");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger();

var services=builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors();
services.AddAppDbContext(builder.Configuration);
services.AddAppAuth(identitySettings);

services.AddAppHealthChecks();
services.AddAppVersioning();

services.AddAppSwagger(identitySettings, swaggerSettings);
services.AddAppAutoMappers();

services.AddAppControllerAndViews();

services.RegisterAppServices(builder);

var app = builder.Build();

app.UseAppHealthChecks();
app.UseAppSwagger();
app.UseAppCors();

// Configure the HTTP request pipeline.

app.UseAppAuth();

app.UseAppControllerAndViews();

app.UseAppMiddlewares();

DbInitializer.Execute(app.Services);

app.Run();
