using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Timesheets.DAL.Settings;

namespace Timesheets.DAL;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TimesheetsDbContext>
{
    //private readonly IOptions<DBConnectionStringsOptions> _setting;

    // public DesignTimeDbContextFactory(IOptions<DBConnectionStringsOptions> setting)
    //{
      //  _setting = setting;
      // }

    public TimesheetsDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TimesheetsDbContext>();
        
        builder.UseSqlServer("Server=ALEX\\SQLEXPRESS; Database=TimeSheets; User Id=dev; Password=123456; TrustServerCertificate=Yes;");       

        return new TimesheetsDbContext(builder.Options);
    }
}