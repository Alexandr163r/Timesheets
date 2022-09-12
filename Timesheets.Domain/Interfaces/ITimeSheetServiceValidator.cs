using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface ITimeSheetServiceValidator
{
    public Task<bool> IsValidIdAsync(Guid id);
    
    Task<bool> IsValidCreateAsync(TimeSheet timeSheet);
}