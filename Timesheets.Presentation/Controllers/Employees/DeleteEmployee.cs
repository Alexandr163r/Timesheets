using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Presentation.Controllers.Employees;

public class DeleteEmployee : EmployeeBase
{
    private readonly IEmployeeService _service;
    
    private readonly IEmployeeServiceValidator _validator;

    public DeleteEmployee(IEmployeeService service, IEmployeeServiceValidator validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpDelete("[area]/{id:guid}")] 
    public async Task<IActionResult> Delete(Guid id)
    {
        var isValid = await _validator.IsValidIdAsync(id);

        if (!isValid)
        {
            return BadRequest("Работник с таким Id не найден");
        }
        
        await _service.DeleteEmployeeAsync(id);

        return Ok();
    }
}