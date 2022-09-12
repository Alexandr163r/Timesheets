using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface ITimeSheetRepository : IBaseRepository<TimeSheet>
{
    public Task<bool> TimeSheetExistByIdAsync(Guid id);
}