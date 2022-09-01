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

    public async Task<bool> AddAsync(EmployeeType entity)
    { 
        await _dbContext.EmployeeTypes.AddAsync(entity);

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

    public async Task<bool> UpdateAsync(Guid id, EmployeeType entity)
    {
        var employeeType = await _dbContext.EmployeeTypes.FindAsync(id);

        if (employeeType == null)
        {
            return false;
        }
        
        employeeType.Title = entity.Title;

        await _dbContext.SaveChangesAsync();

        return true;
    }
}