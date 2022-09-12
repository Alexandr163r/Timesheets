using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface ITimeSheetService
{
    Task<IEnumerable<TimeSheet>> GetAllAsync();
    
    Task<TimeSheet> GetByIdAsync(Guid id);
    
    Task<TimeSheet> AddAsync(TimeSheet timeSheet);
    
    Task<bool> DeleteAsync(Guid id);
    
    Task<bool> UpdateAsync(Guid id, TimeSheet timeSheet);
}