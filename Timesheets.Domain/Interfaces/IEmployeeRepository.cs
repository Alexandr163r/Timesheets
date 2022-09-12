using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public List<Employee> GetByNameAsync(string name, string surname);
    
    public Task<bool> EmployeeExistByIdAsync(Guid id);

    public Task<bool> AddTimeSheetToEmployeeAsync(Guid id, TimeSheet timeSheet);
}