using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Entities;

namespace Timesheets.DAL;

public class TimesheetsDbContext : DbContext
{
    public TimesheetsDbContext(DbContextOptions<TimesheetsDbContext> options) : base(options)
    {
    }
    
    public DbSet<Employee> Employees { get; set; } 

    public DbSet<EmployeeType> EmployeeTypes { get; set; }

    public DbSet<TimeSheet> TimeSheets { get; set; }
    
    public DbSet<ReportInfo> ReportsInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne<EmployeeType>(employee => employee.EmployeeType)
            .WithMany(employeeTypes => employeeTypes.Employees)
            .HasForeignKey(employee => employee.EmployeeTypeId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
            
        
        modelBuilder.Entity<TimeSheet>()
            .HasOne<Employee>(timeSheet => timeSheet.Employee)
            .WithMany(employee => employee.TimeSheets)
            .HasForeignKey(timeSheets => timeSheets.EmployeeId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
        
        base.OnModelCreating(modelBuilder);
    }
}

