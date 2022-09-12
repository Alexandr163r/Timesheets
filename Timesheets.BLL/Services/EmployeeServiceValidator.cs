using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class EmployeeServiceValidator : IEmployeeServiceValidator
{
    private readonly IEmployeeRepository _repository;

    public EmployeeServiceValidator(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> IsValidIdAsync(Guid id)
    {
        var isValidId = await _repository.EmployeeExistByIdAsync(id);

        return isValidId;
    }

    public async Task<bool> IsValidCreateAsync(Employee employee)
    {
        if (employee == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(employee.Name))
        {
            return false;
        }

        if (string.IsNullOrEmpty(employee.Surname))
        {
            return false;
        }

        return true;
    }
}