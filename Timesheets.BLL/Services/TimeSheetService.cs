using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class TimeSheetService : ITimeSheetService
{
    private readonly ITimeSheetRepository _timeSheetRepository;

    public TimeSheetService(ITimeSheetRepository timeSheetRepository)
    {
        _timeSheetRepository = timeSheetRepository;
    }

    public async Task<IEnumerable<TimeSheet>> GetAllAsync()
    {
        var timeSheets = await _timeSheetRepository.GetAllAsync();

        return timeSheets.ToList();
    }

    public async Task<TimeSheet> GetByIdAsync(Guid id)
    {
        return await _timeSheetRepository.GetByIdAsync(id);
    }

    public async Task<TimeSheet> AddAsync(TimeSheet timeSheet)
    {
        return await _timeSheetRepository.AddAsync(timeSheet);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _timeSheetRepository.DeleteAsync(id);
    }

    public async Task<bool> UpdateAsync(Guid id, TimeSheet timeSheet)
    {
        return await _timeSheetRepository.UpdateAsync(id, timeSheet);
    }
}