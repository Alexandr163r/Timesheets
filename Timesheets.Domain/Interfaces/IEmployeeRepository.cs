using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public List<Employee> GetByNameAsync(string name, string surname);
}