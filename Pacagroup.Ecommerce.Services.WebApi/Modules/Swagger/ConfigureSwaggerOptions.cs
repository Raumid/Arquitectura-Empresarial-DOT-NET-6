using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "Pacagroup Technology Services API Market",
                Description = "A simple example ASP.NET Core Web API",
                TermsOfService = new Uri("https://pacagroup.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Raumid Santiz Felipe",
                    Email = "raumid98@gmail.com",
                    Url = new Uri("https://pacagroup.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://example.com.license")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "\n  Esta versión de la API ha quedado obsoleta";
            }

            return info;
        }
    }
}
