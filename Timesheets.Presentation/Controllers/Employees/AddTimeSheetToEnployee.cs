using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.TimeSheet;

namespace Timesheets.Presentation.Controllers.Employees;

public class AddTimeSheetToEnployee : EmployeeBase
{
    private readonly IEmployeeService _service;

    private readonly IMapper _mapper;

    private readonly IEmployeeServiceValidator _employeeServiceValidator;

    public AddTimeSheetToEnployee(IEmployeeService service, IMapper mapper,
        IEmployeeServiceValidator employeeServiceValidator)
    {
        _service = service;
        _mapper = mapper;
        _employeeServiceValidator = employeeServiceValidator;
    }

    [HttpPost("[area]/Add_TimeSheet/{id:guid}")]
    public async Task<IActionResult> AddEmployeeIn([FromBody] TimeSheetResponseModel responseModel, Guid id)
    {
        var isValidId = await _employeeServiceValidator.IsValidIdAsync(id);

        if (!isValidId)
        {
            return BadRequest("Работник с таким Id не найден");
        }
        
        var timeSheet = _mapper.Map<TimeSheet>(responseModel);
        
        await _service.AddTimeSheetToEmployeeAsync(id, timeSheet);
        
        return Ok();
    }
}