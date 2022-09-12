using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Timesheets.DAL;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TimesheetsDbContext>
{
    TimesheetsDbContext IDesignTimeDbContextFactory<TimesheetsDbContext>.CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(@"C:\GitHub\RiderProject\Timesheets\Timesheets.Presentation\")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var builder = new DbContextOptionsBuilder<TimesheetsDbContext>();
        var connectionString = configuration.GetSection("DBConnectionStrings")["MSSQLConnection"];

        builder.UseSqlServer(connectionString);

        return new TimesheetsDbContext(builder.Options);
    }
}