using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IEmployeeTypeServiceValidator
{
    Task<bool> IsValidCreate(EmployeeType employeeType);

    Task<bool> IsValidTitleAsync(string title);

    public Task<bool> IsValidIdAsync(Guid id);
}