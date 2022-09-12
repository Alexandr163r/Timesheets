using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class EmployeeTypeService : IEmployeeTypeService
{
    private readonly IEmployeeTypeRepository _employeeTypeRepository;

    private readonly IEmployeeRepository _employeeRepository;


    public EmployeeTypeService(IEmployeeTypeRepository employeeTypeRepository, IEmployeeRepository employeeRepository)
    {
        _employeeTypeRepository = employeeTypeRepository;
        _employeeRepository = employeeRepository;
    }
    
    public async Task<List<EmployeeType>> GetAllEmployeeTypeAsync()
    {
        var employeeTypes = await _employeeTypeRepository.GetAllAsync();

        return employeeTypes.ToList();
    }

    public async Task<EmployeeType> GetEmployeeTypeByIdAsync(Guid id)
    {
        return await _employeeTypeRepository.GetByIdAsync(id);
    }

    public async Task<EmployeeType> AddEmployeeTypeAsync(EmployeeType entityEmployeeType)
    {
        return await _employeeTypeRepository.AddAsync(entityEmployeeType);
    }

    public async Task<bool> DeleteEmployeeTypeAsync(Guid id)
    {
        return await _employeeTypeRepository.DeleteAsync(id);
    }

    public async Task<bool> UpdateAsync(Guid id, EmployeeType entityEmployeeType)
    {
        return await _employeeTypeRepository.UpdateAsync(id, entityEmployeeType);
    }

    public async Task<EmployeeType> GetEmployeeTypeByTitleAsync(string title)
    {
        return await _employeeTypeRepository.GetEmployeeTypeByTitleAsync(title);
    }

    public async Task<bool> AddEmployeeInListAsync(string title, Employee employee)
    {
        var id = _employeeTypeRepository.GetEmployeeTypeByTitleAsync(title).Result;

        employee.EmployeeTypeId = id.Id;

        var updateEmployee = await _employeeRepository.AddAsync(employee);
        
        
        await _employeeTypeRepository.AddEmployeeInListAsync(title, updateEmployee);
        
        return true;
    }
}
