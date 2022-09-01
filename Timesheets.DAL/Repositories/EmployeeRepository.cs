using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.DAL.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly TimesheetsDbContext _dbContext;

    public EmployeeRepository(TimesheetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _dbContext.Employees.AsQueryable().ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(Guid id)
    {
        var employee = await _dbContext.Employees.FindAsync(id);

        return employee;
    }

    public async Task<bool> AddAsync(Employee entity)
    {
        await _dbContext.Employees.AddAsync(entity);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _dbContext.EmployeeTypes.FindAsync(id);

        if (entity == null)
        {
            return false;
        }

        _dbContext.EmployeeTypes.Remove(entity);

        return true;
    }
    
    public async Task<bool> UpdateAsync(Guid id, Employee entity)
    {
        var employee = await _dbContext.Employees.FindAsync(id);

        if (employee == null)
        {
            return false;
        }

        employee.Name = employee.Name;
        employee.Surname = employee.Surname;
        employee.EmployeeTypeId = employee.EmployeeTypeId;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public List<Employee> GetByNameAsync(string name, string surname)
    {
        var employee = _dbContext.Employees.Where(e => e.Name == name || e.Surname == surname).ToList();

        return employee;
    }
}
    