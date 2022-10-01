using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Timesheets.BLL.Services;
using Timesheets.DAL;
using Timesheets.DAL.Entity;
using Timesheets.DAL.Repositories;
using Timesheets.DAL.Settings;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Converter;
using Timesheets.Presentation.Extensions;
using Timesheets.Presentation.Settings;

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
        
        var dbSettings = Configuration.GetSection(nameof(MSSQLDBSetting)).Get<MSSQLDBSetting>();
        
        services.AddDbContext<TimesheetsDbContext>(options =>
            options.UseSqlServer(dbSettings.ConnectionStrings)).AddIdentity<ApplicationUser, ApplicationRole>(opt => opt.Password.RequireDigit = false).AddEntityFrameworkStores<TimesheetsDbContext>().AddDefaultTokenProviders();
        
        services.AddJWT(Configuration);
        
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Bearer";
                options.DefaultChallengeScheme = "Identity.Application";
            })
            .AddPolicyScheme("JWT_OR_COOKIE", "JWT_OR_COOKIE", options =>
            {
                options.ForwardDefaultSelector = context =>
                {
                    string authorization = context.Request.Headers[HeaderNames.Authorization];
                    if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer"))
                        return "Bearer";
                    return "Identity.Application";
                };
            });

        services.Configure<JWTSetting>(this.Configuration.GetSection(nameof(JWTSetting)));
        
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
        services.AddScoped<IReportServiceValidator, ReportServiceValidator>();
        
        services.Configure<MSSQLDBSetting>(
            Configuration.GetSection(nameof(MSSQLDBSetting)));
        
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
        });
        
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