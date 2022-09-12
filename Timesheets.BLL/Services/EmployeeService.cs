using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    private readonly ITimeSheetRepository _timeSheetRepository;
    
    public EmployeeService(IEmployeeRepository employeeRepository, ITimeSheetRepository timeSheetRepository)
    {
        _employeeRepository = employeeRepository;
        _timeSheetRepository = timeSheetRepository;
    }

    public async Task<List<Employee>> GetAllEmployeeAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();

        return employees.ToList();
    }

    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task<Employee> AddEmployeeAsync(Employee entityEmployee)
    {
        return await _employeeRepository.AddAsync(entityEmployee);
    }

    public async Task<bool> DeleteEmployeeAsync(Guid id)
    {
        return await _employeeRepository.DeleteAsync(id);
    }

    public async Task<bool> UpdateAsync(Guid id, Employee entityEmployee)
    {
        return await _employeeRepository.UpdateAsync(id, entityEmployee);
    }

    public async Task<bool> AddTimeSheetToEmployeeAsync(Guid id, TimeSheet timeSheet)
    {
        timeSheet.EmployeeId = id;
        
        timeSheet.WorkingTime = timeSheet.EndOfWorkDay - timeSheet.StartOfWorkDay;

        var updateTimeSteet = await _timeSheetRepository.AddAsync(timeSheet);
        
        await _employeeRepository.AddTimeSheetToEmployeeAsync(id, updateTimeSteet);

        return true;
    }
}