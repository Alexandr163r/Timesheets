using System.Text;

namespace Timesheets.Presentation;

public class Program
{
    private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(
            (hostingContext, builder) =>
            {
                builder
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.Development.json", false, true)
                    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true,
                        true)
                    .AddEnvironmentVariables();
            })
        .ConfigureWebHostDefaults(
            webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls(new[] { "http://localhost:5000" });
                webBuilder.ConfigureKestrel(
                    options => { options.AddServerHeader = false; });
            });

    public static void Main(string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        CreateHostBuilder(args).Build().Run();
    }
}