using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Entities;

namespace Timesheets.DAL;

public class TimesheetsDbContext : DbContext
{
    public TimesheetsDbContext(DbContextOptions<TimesheetsDbContext> options) : base(options)
    {
    }
    
    public DbSet<Employee>? Employee { get; set; } 

    public DbSet<EmployeeType>? EmployeeType { get; set; }

    public DbSet<TimeSheet>? TimeSheet { get; set; }
}

