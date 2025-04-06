namespace Pacagroup.Ecommerce.Services.WebApi.Modules.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "database"});
            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }
    }
}
