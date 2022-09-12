using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IEmployeeTypeRepository : IBaseRepository<EmployeeType>
{
    Task<EmployeeType> GetEmployeeTypeByTitleAsync(string title);
    
    Task<bool> AddEmployeeInListAsync(string title, Employee employee);
    
    Task<bool> EmployeeTypeExistByTitleAsync(string title);

    public Task<bool> EmployeeTypeExistByIdAsync(Guid id);
}