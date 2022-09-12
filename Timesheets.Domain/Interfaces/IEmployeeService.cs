using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllEmployeeAsync();
    
    Task<Employee> GetEmployeeByIdAsync(Guid id);
    
    Task<Employee> AddEmployeeAsync(Employee entityEmployee);
    
    Task<bool> DeleteEmployeeAsync(Guid id);
    
    Task<bool> UpdateAsync(Guid id, Employee entityEmployee);

    public Task<bool> AddTimeSheetToEmployeeAsync(Guid id, TimeSheet timeSheet);
}