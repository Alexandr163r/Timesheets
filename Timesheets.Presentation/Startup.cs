using Microsoft.EntityFrameworkCore;
using Timesheets.BLL.Services;
using Timesheets.DAL;
using Timesheets.DAL.Repositories;
using Timesheets.DAL.Settings;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Converter;

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
        services.AddAutoMapper(typeof(AppMappingProfile));
        
        services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        
        services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ITimeSheetService, TimeSheetService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IGenerateExcelService, GenerateExcelService>();
       
        services.AddScoped<IEmployeeTypeServiceValidator, EmployeeTypeServiceValidator>();
        services.AddScoped<IEmployeeServiceValidator, EmployeeServiceValidator>();
        services.AddScoped<ITimeSheetServiceValidator, TimeSheetServiceValidator>();
        
        services.Configure<MSSQLDBSetting>(
            Configuration.GetSection(nameof(MSSQLDBSetting)));
        
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
        });
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();

        var dbSettings = Configuration.GetSection(nameof(MSSQLDBSetting)).Get<MSSQLDBSetting>();
        
        services.AddDbContext<TimesheetsDbContext>(options =>
            options.UseSqlServer(dbSettings.ConnectionStrings));
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