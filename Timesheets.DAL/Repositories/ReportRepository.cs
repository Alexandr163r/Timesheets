using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Dto;
using Timesheets.Domain.Interfaces;

namespace Timesheets.DAL.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly TimesheetsDbContext _dbContext;

    public ReportRepository(TimesheetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ReportDto>> GetReportByIdAsync(Guid id)
    {
        var reports = await (from employee in _dbContext.Employees 
                join employeeType in _dbContext.EmployeeTypes on employee.EmployeeTypeId equals employeeType.Id
                join timeSheet in _dbContext.TimeSheets on employee.Id equals timeSheet.EmployeeId
                where employee.Id == id
                select new ReportDto()
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
}