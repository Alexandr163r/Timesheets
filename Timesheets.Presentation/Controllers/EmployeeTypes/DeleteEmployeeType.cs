using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Presentation.Controllers.EmployeeTypes;

public class DeleteEmployeeType : EmployeeTypeBase
{
    private readonly IEmployeeTypeService _service;
    
    private readonly IEmployeeTypeServiceValidator _validator;

    public DeleteEmployeeType(IEmployeeTypeService service, IEmployeeTypeServiceValidator validator)
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
            return BadRequest("Должность не найдена");
        }

        await _service.DeleteEmployeeTypeAsync(id);
       
        return Ok();
    }
}