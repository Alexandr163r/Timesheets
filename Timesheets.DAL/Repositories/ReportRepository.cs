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

    public async Task<List<ReportCard>> GetReportByIdAsync(Guid id)
    {
        var reports = await (from employee in _dbContext.Employees 
                join employeeType in _dbContext.EmployeeTypes on employee.EmployeeTypeId equals employeeType.Id
                join timeSheet in _dbContext.TimeSheets on employee.Id equals timeSheet.EmployeeId
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

    public async Task<List<ReportCard>> GetReportBySelectorAsync(ReportCard reportDto)
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
}


