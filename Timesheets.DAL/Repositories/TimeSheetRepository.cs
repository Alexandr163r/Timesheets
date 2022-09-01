using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.DAL.Repositories;

public class TimeSheetRepository : ITimeSheetRepository
{
    private readonly TimesheetsDbContext _dbContext;

    public TimeSheetRepository(TimesheetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TimeSheet>> GetAllAsync()
    {
        return await _dbContext.TimeSheets.AsQueryable().ToListAsync();
    }

    public async Task<TimeSheet> GetByIdAsync(Guid id)
    {
        var timeSheet = await _dbContext.TimeSheets.FindAsync(id);

        return timeSheet;
    }

    public async Task<bool> AddAsync(TimeSheet entity)
    {
        await _dbContext.TimeSheets.AddAsync(entity);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var timeSheet = await _dbContext.TimeSheets.FindAsync(id);

        if (timeSheet == null)
        {
            return false;
        }

        _dbContext.TimeSheets.Remove(timeSheet);

        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, TimeSheet entity)
    {
        var timeSheet = await _dbContext.TimeSheets.FindAsync(id);

        if (timeSheet == null)
        {
            return false;
        }
        
        timeSheet.EndOfWorkDay = entity.EndOfWorkDay;
        timeSheet.StartOfWorkDay = entity.StartOfWorkDay;
        timeSheet.EmployeeId = entity.EmployeeId;
        
        await _dbContext.SaveChangesAsync();

        return true;
    }
}