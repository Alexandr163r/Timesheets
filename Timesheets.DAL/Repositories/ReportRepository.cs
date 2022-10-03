using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.DAL.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly TimesheetsDbContext _dbContext;

    public ReportRepository(TimesheetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ReportCard>> GetReportCardByIdAsync(Guid id)
    {
        var reports = await (from employee in _dbContext.Employees
                join employeeType in _dbContext.EmployeeTypes on employee.EmployeeTypeId equals employeeType.Id
                join timeSheet in _dbContext.TimeSheets on employee.Id equals timeSheet.EmployeeId
                orderby timeSheet.StartOfWorkDay descending 
                where employee.Id == id
                select new ReportCard()
                {
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Title = employeeType.Title,
                    StartOfWorkDay = timeSheet.StartOfWorkDay,
                    EndOfWorkDay = timeSheet.EndOfWorkDay,
                    WorkTime = timeSheet.WorkingTime
                }
            ).Take(63).ToListAsync();

        return reports;
    }

    public async Task<List<ReportCard>> GetReportCardBySelectorAsync(ReportCard reportDto)
    {
        var reports = await (from employee in _dbContext.Employees
                join employeeType in _dbContext.EmployeeTypes on employee.EmployeeTypeId equals employeeType.Id
                join timeSheet in _dbContext.TimeSheets on employee.Id equals timeSheet.EmployeeId
                where (timeSheet.StartOfWorkDay <= reportDto.EndOfWorkDay)
                      && (timeSheet.EndOfWorkDay >= reportDto.StartOfWorkDay)
                      && (reportDto.Name == null || (employee.Name == reportDto.Name))
                      && (reportDto.Surname == null || employee.Surname == reportDto.Surname)
                select new ReportCard()
                {
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Title = employeeType.Title,
                    StartOfWorkDay = timeSheet.StartOfWorkDay,
                    EndOfWorkDay = timeSheet.EndOfWorkDay,
                    WorkTime = timeSheet.WorkingTime
                }
            ).ToListAsync();

        return reports;
    }

    public async Task<Guid> CreateReportAsync(List<ReportCard> reportCards)
    {
        var report = new Report();

        report.Reports = reportCards;

        await _dbContext.Reports.AddAsync(report);

        await _dbContext.SaveChangesAsync();

        return report.Id;
    }

    public async Task IsDeleteReportAsync(Report report)
    {
        report.IsDeleted = true;

        await _dbContext.SaveChangesAsync();
    }

    public async Task IsDownloadedReportAsync(Report report)
    {
        report.IsDawnloaded = true;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Report> GetByIdAsync(Guid id)
    {
        var report = await _dbContext.Reports.Include(r => r.Reports)
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();

        return report;
    }

    public async Task<bool> ExistByIdAsync(Guid id)
    {
        var exist = await _dbContext.Reports.AnyAsync(r => r.Id == id);

        return exist;
    }
}