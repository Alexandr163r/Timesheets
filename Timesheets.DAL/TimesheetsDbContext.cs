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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne("Timesheets.Domain.Entities.EmployeeType", null)
            .WithMany("Employees")
            .HasForeignKey("EmployeeTypeId")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        
        modelBuilder.Entity<TimeSheet>()
            .HasOne("Timesheets.Domain.Entities.Employee", null)
            .WithMany("TimeSheets")
            .HasForeignKey("EmployeeId")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}

