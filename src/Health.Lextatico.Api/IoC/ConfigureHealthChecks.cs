using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Health.Lextatico.Api.IoC
{
    public static class ConfigureHealthChecks
    {
        public static IServiceCollection AddLextaticoHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();

            services.AddHealthChecksUI(settings =>
            {
                settings.SetHeaderText("MicroServices status");
            })
                .AddInMemoryStorage();

            return services;
        }
    }
}
