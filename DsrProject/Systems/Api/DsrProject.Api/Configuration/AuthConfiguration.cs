﻿using DsrProject.Common.Security;
using DsrProject.Context;
using DsrProject.Context.Entities;
using DsrProject.Services.Settings;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DsrProject.Api.Configuration
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAppAuth(this IServiceCollection services, IdentitySettings settings)
        {
            IdentityModelEventSource.ShowPII = true;

            services
                .AddIdentity<User, IdentityRole<Guid>>(opt =>
                {
                    opt.Password.RequiredLength = 0;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<MainDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.RequireHttpsMetadata = settings.Url.StartsWith("https://");
                    options.Authority = settings.Url;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = false,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    options.Audience = "api";
                });


            services.AddAuthorization(options =>
            {
                options.AddPolicy(AppScopes.ThoughtsRead, policy => policy.RequireClaim("scope", AppScopes.ThoughtsRead));
                options.AddPolicy(AppScopes.ThoughtsWrite, policy => policy.RequireClaim("scope", AppScopes.ThoughtsWrite));
            });

            return services;
        }

        public static IApplicationBuilder UseAppAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }
    }
}