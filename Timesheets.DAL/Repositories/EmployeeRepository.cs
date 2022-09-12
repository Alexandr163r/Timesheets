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

    public async Task<Employee> AddAsync(Employee employee)
    {
        var newEmployee = await _dbContext.Employees.AddAsync(employee);

        await _dbContext.SaveChangesAsync();

        return newEmployee.Entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var employee = await _dbContext.Employees.FindAsync(id);

        _dbContext.Employees.Remove(employee);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, Employee employee)
    {
        var newEmployee = await _dbContext.Employees.FindAsync(id);
        
        newEmployee.Name = employee.Name;
        newEmployee.Surname = employee.Surname;
        newEmployee.EmployeeTypeId = employee.EmployeeTypeId;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public List<Employee> GetByNameAsync(string name, string surname)
    {
        var employee = _dbContext.Employees.Where(e => e.Name == name || e.Surname == surname).ToList();

        return employee;
    }

    public async Task<bool> EmployeeExistByIdAsync(Guid id)
    {
        var existId = await _dbContext.Employees.AnyAsync(e => e.Id == id);

        return existId;
    }

    public async Task<bool> AddTimeSheetToEmployeeAsync(Guid id, TimeSheet timeSheet)
    {
        var employee = await _dbContext.Employees.FirstAsync(e => e.Id == id);
        
        employee.TimeSheets.Add(timeSheet);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}