using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace OtripleS.Portal.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var startup = new Startup(builder.Configuration);

            startup.Configure(builder.RootComponents);
            startup.ConfigureServices(builder.Services);

            await builder
                .Build()
                .RunAsync();
        }
    }
}