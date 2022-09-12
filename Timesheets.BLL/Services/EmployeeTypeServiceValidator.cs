using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class EmployeeTypeServiceValidator : IEmployeeTypeServiceValidator
{
    private readonly IEmployeeTypeRepository _repository;

    public EmployeeTypeServiceValidator(IEmployeeTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> IsValidCreate(EmployeeType employeeType)
    {
        if (employeeType == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(employeeType.Title))
        {
            return false;
        }

        var existTitle = await _repository.EmployeeTypeExistByTitleAsync(employeeType.Title);

        if (existTitle)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> IsValidTitleAsync(string title)
    {
        var existTitle = await _repository.EmployeeTypeExistByTitleAsync(title);

        return existTitle;
    }

    public async Task<bool> IsValidIdAsync(Guid id)
    {
        var existId = await _repository.EmployeeTypeExistByIdAsync(id);

        return existId;
    }
}