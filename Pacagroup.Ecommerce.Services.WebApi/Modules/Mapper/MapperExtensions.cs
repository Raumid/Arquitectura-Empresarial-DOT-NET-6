namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            // Configure AutoMapper
            services.AddAutoMapper(typeof(Pacagroup.Ecommerce.Transversal.Mapper.MappingsProfile));

            return services;
        }
    }
}
