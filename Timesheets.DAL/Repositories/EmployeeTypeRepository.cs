using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.DAL.Repositories;

public class EmployeeTypeRepository : IEmployeeTypeRepository
{
    private readonly TimesheetsDbContext _dbContext;

    public EmployeeTypeRepository(TimesheetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<EmployeeType>> GetAllAsync()
    {
        return await _dbContext.EmployeeTypes.AsQueryable().ToListAsync();
    }

    public async Task<EmployeeType> GetByIdAsync(Guid id)
    {
        var employeeTypes = await _dbContext.EmployeeTypes.FindAsync(id);

        return employeeTypes;
    }

    public async Task<EmployeeType> AddAsync(EmployeeType employeeType)
    {
        var newEmployeeType = await _dbContext.EmployeeTypes.AddAsync(employeeType);

        await _dbContext.SaveChangesAsync();

        return newEmployeeType.Entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var employeeType = await _dbContext.EmployeeTypes.FindAsync(id);

        if (employeeType == null)
        {
            return false;
        }

        _dbContext.EmployeeTypes.Remove(employeeType);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, EmployeeType employeeType)
    {
        var newEmployeeType = await _dbContext.EmployeeTypes.FindAsync(id);

        if (newEmployeeType == null)
        {
            return false;
        }

        newEmployeeType.Title = employeeType.Title;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<EmployeeType> GetEmployeeTypeByTitleAsync(string title)
    {
        var employeeType = await _dbContext.EmployeeTypes.FirstAsync(e => e.Title.ToLower() == title.ToLower());
        
        await _dbContext.SaveChangesAsync();

        return employeeType;
    }

    public async Task<bool> AddEmployeeInListAsync(string title, Employee employee)
    {
        var employeeType = await _dbContext.EmployeeTypes.FirstAsync(e => e.Title.ToLower() == title.ToLower());

        employeeType.Employees.Add(employee);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> EmployeeTypeExistByTitleAsync(string title)
    {
        var existTitle = await _dbContext.EmployeeTypes.AnyAsync(e => e.Title == title);

        return existTitle;
    }
    
    public async Task<bool> EmployeeTypeExistByIdAsync(Guid id)
    {
        var existId = await _dbContext.EmployeeTypes.AnyAsync(e => e.Id == id);

        return existId;
    }
}