using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IEmployeeServiceValidator
{
    public Task<bool> IsValidIdAsync(Guid id);
    
    Task<bool> IsValidCreateAsync(Employee employee);
}