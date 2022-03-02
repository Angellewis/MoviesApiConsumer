using Microsoft.Extensions.DependencyInjection;
using MoviesApi.Services.Contracts;

namespace MoviesApi.Services.IoC
{
    public static class ServiceRegistry
    {
        public static void AddServicesRegistry(this IServiceCollection services)
        {
            services.AddTransient<IApiHelper, ApiHelper>();
        }
    }
}
