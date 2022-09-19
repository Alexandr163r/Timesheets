using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.Employee;

namespace Timesheets.Presentation.Controllers.EmployeeTypes;

public class AddEmployeeInEnployeeType : EmployeeTypeBase
{
    private readonly IEmployeeTypeService _service;

    private readonly IMapper _mapper;

    private readonly IEmployeeTypeServiceValidator _employeeTypeServiceValidator;

    private readonly IEmployeeServiceValidator _employeeServiceValidator;

    public AddEmployeeInEnployeeType(IEmployeeTypeService service, IMapper mapper, IEmployeeTypeServiceValidator employeeTypeServiceValidator, IEmployeeServiceValidator employeeServiceValidator)
    {
        _service = service;
        _mapper = mapper;
        _employeeTypeServiceValidator = employeeTypeServiceValidator;
        _employeeServiceValidator = employeeServiceValidator;
    }


    [HttpPost("[area]/Add_Employee/{title}")]
    public async Task<IActionResult> AddEmployeeIn([FromBody] EmployeeResponseModel responseModel, string title)
    {
        var isValidTitle = await _employeeTypeServiceValidator.IsValidTitleAsync(title);

        if (!isValidTitle)
        {
            return BadRequest("Должность не найдена");
        }
        
        var employee = _mapper.Map<Employee>(responseModel);

        var isValidEmployee = await _employeeServiceValidator.IsValidCreateAsync(employee);

        if (!isValidEmployee)
        {
            return BadRequest("Форма работника не заполнина");
        }
        
        await _service.AddEmployeeInListAsync(title, employee);

        return Ok();
    }
}