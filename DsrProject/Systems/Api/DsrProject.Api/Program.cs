using DSRNetSchool.Context;
using DsrProject.Api;
using DsrProject.Api.Configuration;
using DsrProject.Api.Settings;
using DsrProject.Context;
using DsrProject.Services.Settings;
using DsrProject.Settings;

var builder = WebApplication.CreateBuilder(args);

var mainSettings = Settings.Load<MainSettings>("Main");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger();

var services=builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors();
services.AddAppDbContext(builder.Configuration);

services.AddAppHealthChecks();
services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings);
services.AddAppControllerAndViews();

services.RegisterAppServices(builder);


var app = builder.Build();

app.UseAppHealthChecks();
app.UseAppSwagger();

DbInitializer.Execute(app.Services);


// Configure the HTTP request pipeline.

app.UseAppControllerAndViews();

app.Run();
