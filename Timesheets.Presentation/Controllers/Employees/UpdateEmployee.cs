using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.Employee;

namespace Timesheets.Presentation.Controllers.Employees;

public class UpdateEmployee : EmployeeBase
{
    private readonly IEmployeeService _service;

    private readonly IMapper _mapper;

    private readonly IEmployeeServiceValidator _validator;

    public UpdateEmployee(IEmployeeService service, IMapper mapper, IEmployeeServiceValidator validator)
    {
        _service = service;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpPut("[area]{id:guid}")]
    public async Task<IActionResult> Update([FromBody] EmployeeResponseModel responseModel, Guid id)
    {
        var isvalidId = await _validator.IsValidIdAsync(id);

        if (!isvalidId)
        {
            return BadRequest("Работник с таким Id не найден");
        }
        
        var employee = _mapper.Map<Employee>(responseModel);

        var isValid = await _validator.IsValidCreateAsync(employee);

        if (!isValid)
        {
            return BadRequest("Поле не заполнено");
        }

        await _service.UpdateAsync(id, employee);

        return Ok();
    }
}

