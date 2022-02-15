using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace OtripleS.Portal.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Configure(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
        }

        public void ConfigureServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(x => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });
        }

        public IConfiguration Configuration { get; }
    }
}