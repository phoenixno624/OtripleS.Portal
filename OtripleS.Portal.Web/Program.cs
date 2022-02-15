using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace OtripleS.Portal.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var startup = new Startup(builder.Configuration);

            startup.Configure(builder);
            startup.ConfigureServices(builder);

            await builder
                .Build()
                .RunAsync();
        }
    }
}