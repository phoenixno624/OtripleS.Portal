using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OtripleS.Portal.Web.Brokers.Api;
using OtripleS.Portal.Web.Brokers.Logging;
using OtripleS.Portal.Web.Models.Configurations;
using RESTFulSense.WebAssembly.Clients;

namespace OtripleS.Portal.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        public void Configure(RootComponentMappingCollection components)
        {
            components.Add<App>("#app");
            components.Add<HeadOutlet>("head::after");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AddHttpClient(services);

            services.AddScoped<ILogger, Logger<LoggingBroker>>();
            services.AddScoped<IApiBroker, ApiBroker>();
            services.AddScoped<ILoggingBroker, LoggingBroker>();
        }

        void AddHttpClient(IServiceCollection services)
        {
            services.AddHttpClient<IRESTFulApiFactoryClient, RESTFulApiFactoryClient>(client =>
            {
                var localConfigurations = Configuration.Get<LocalConfigurations>();
                var apiUrl = localConfigurations.ApiConfigurations.Url;

                client.BaseAddress = new Uri(apiUrl);
            });
        }

        public IConfiguration Configuration { get; }
    }
}