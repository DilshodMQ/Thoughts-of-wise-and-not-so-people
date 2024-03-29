using DsrProject.Context;
using DsrProject.Identity;
using DsrProject.Identity.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var services = builder.Services;

services.AddAppCors();

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppHealthChecks();

services.RegisterAppServices();

services.AddIS4();

var app = builder.Build();

app.UseAppHealthChecks();
app.UseAppCors();

app.UseIS4();

app.Run();


