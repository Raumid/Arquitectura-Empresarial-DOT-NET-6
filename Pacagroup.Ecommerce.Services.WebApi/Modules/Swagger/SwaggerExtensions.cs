using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            //ADD VERSIONING
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(options =>
             {
                 //Se migra a ./ConfitureSwaggerOptions.cs
                //options.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Version = "v1",
                //    Title = "Pacagroup Technology Services API Market",
                //    Description = "A simple example ASP.NET Core Web API",
                //    TermsOfService = new Uri("https://pacagroup.com/terms"),
                //    Contact = new OpenApiContact
                //    {
                //        Name = "Raumid Santiz Felipe",
                //        Email = "raumid98@gmail.com",
                //        Url = new Uri("https://pacagroup.com/contact")
                //    },
                //    License = new OpenApiLicense
                //    {
                //        Name = "Use under LICX",
                //        Url = new Uri("https://example.com.license")
                //    }
                //});

                options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme,
                    securityScheme: new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Description = "Please insert your JWT Token into field",
                        Type = SecuritySchemeType.ApiKey,
                        In = ParameterLocation.Header,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        }, new string [] { }
                    }
                });
             });

            return services;
        }
    }
}
