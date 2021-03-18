using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sovtechTest.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configdict = new Dictionary<string, string>();
            configdict.Add("EndPoint", "https://api.chucknorris.io/jokes/random");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Configuration.AddInMemoryCollection(configdict);
            AddServices(builder);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            await builder.Build().RunAsync();

            static void AddServices(WebAssemblyHostBuilder builder)
            {
                builder.Services.AddSingleton<ChuckNorrisService>();
                //builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)}); ;
            }
        }
    }
}
