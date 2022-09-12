using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class TimeSheetServiceValidator : ITimeSheetServiceValidator
{
    private readonly ITimeSheetRepository _repository;

    public TimeSheetServiceValidator(ITimeSheetRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> IsValidIdAsync(Guid id)
    {
        var isValidId = await _repository.TimeSheetExistByIdAsync(id);

        return isValidId;
    }

    public Task<bool> IsValidCreateAsync(TimeSheet timeSheet)
    {
        throw new NotImplementedException();
    }
}