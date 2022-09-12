using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IEmployeeTypeService
{
    Task<List<EmployeeType>> GetAllEmployeeTypeAsync();
    
    Task<EmployeeType> GetEmployeeTypeByIdAsync(Guid id);
    
    Task<EmployeeType> AddEmployeeTypeAsync(EmployeeType entityEmployeeType);
    
    Task<bool> DeleteEmployeeTypeAsync(Guid id);
    
    Task<bool> UpdateAsync(Guid id, EmployeeType entityEmployeeType);
    
    Task<EmployeeType> GetEmployeeTypeByTitleAsync(string title);
    
    Task<bool> AddEmployeeInListAsync(string title, Employee employee);
}