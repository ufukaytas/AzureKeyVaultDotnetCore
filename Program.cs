using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AzureKeyVaultDotnetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((ctx, config) =>
               {
                  var root = config.Build();
                config.AddAzureKeyVault(
                    $"https://{root["KeyVault:Vault"]}.vault.azure.net/",
                    root["KeyVault:ClientId"],
                    root["KeyVault:ClientSecret"]);
                });
    }
}
