using Microsoft.EntityFrameworkCore;
using Timesheets.DAL;
using Timesheets.DAL.Settings;

namespace Timesheets.Presentation;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<DBConnectionStringsSetting>(
            Configuration.GetSection("DBConnectionStrings"));
        
        services.AddDbContext<TimesheetsDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MSSQLConnection")));
        
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        {
            app.UseSwagger();

            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(
            endpoints => { endpoints.MapControllers(); });
    }
}