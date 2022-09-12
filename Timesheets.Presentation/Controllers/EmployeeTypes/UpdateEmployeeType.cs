using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.EmployeeType;

namespace Timesheets.Presentation.Controllers.EmployeeTypes;

public class UpdateEmployeeType : EmployeeTypeBase
{
    private readonly IEmployeeTypeService _service;

    private readonly IMapper _mapper;

    private readonly IEmployeeTypeServiceValidator _validator;

    public UpdateEmployeeType(IEmployeeTypeService service, IMapper mapper, IEmployeeTypeServiceValidator validator)
    {
        _service = service;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpPut("[area]{id:guid}")]
    public async Task<IActionResult> Update([FromBody] EmployeeTypeResponseModel responseModel, Guid id)
    {
        var isvalidId = await _validator.IsValidIdAsync(id);

        if (!isvalidId)
        {
            return BadRequest("Должности с таким Id не найдено");
        }
        
        var employeeType = _mapper.Map<EmployeeType>(responseModel);

        var isValid = await _validator.IsValidCreate(employeeType);

        if (!isValid)
        {
            return BadRequest("Поле не заполнено или должность с таким названием уже существует ");
        }

        await _service.UpdateAsync(id, employeeType);

        return Ok();
    }
}