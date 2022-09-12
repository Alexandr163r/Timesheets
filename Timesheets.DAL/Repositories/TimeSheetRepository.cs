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

    public async Task<TimeSheet> AddAsync(TimeSheet timeSheet)
    {
        var newTimeSheet = await _dbContext.TimeSheets.AddAsync(timeSheet);

        await _dbContext.SaveChangesAsync();
        
        return newTimeSheet.Entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var timeSheet = await _dbContext.TimeSheets.FindAsync(id);

        if (timeSheet == null)
        {
            return false;
        }
        
        _dbContext.TimeSheets.Remove(timeSheet);
        
        await _dbContext.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, TimeSheet timeSheet)
    {
        var newTimeSheet = await _dbContext.TimeSheets.FindAsync(id);

        if (newTimeSheet == null)
        {
            return false;
        }
        
        newTimeSheet.EndOfWorkDay = timeSheet.EndOfWorkDay;
        newTimeSheet.StartOfWorkDay = timeSheet.StartOfWorkDay;
        newTimeSheet.EmployeeId = timeSheet.EmployeeId;

        await _dbContext.SaveChangesAsync();
        
        return true;
    }
    
    public async Task<bool> TimeSheetExistByIdAsync(Guid id)
    {
        var existId = await _dbContext.TimeSheets.AnyAsync(e => e.Id == id);

        return existId;
    }
}