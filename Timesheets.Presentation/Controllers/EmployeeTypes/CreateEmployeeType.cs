using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.EmployeeType;

namespace Timesheets.Presentation.Controllers.EmployeeTypes;

public class CreateEmployeeType : EmployeeTypeBase
{
    private readonly IEmployeeTypeService _service;

    private readonly IMapper _mapper;

    private readonly IEmployeeTypeServiceValidator _validator;
    
    public CreateEmployeeType(IEmployeeTypeService service, IMapper mapper, IEmployeeTypeServiceValidator validator)
    {
        _service = service;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpPost("[area]")]
    public async Task<IActionResult> Create([FromBody] EmployeeTypeResponseModel responseModel)
    {
        var employeeType = _mapper.Map<EmployeeType>(responseModel);

        var isValid = await _validator.IsValidCreate(employeeType);

        if (!isValid)
        {
            return BadRequest("Такая должность уже существует");
        }
        
        await _service.AddEmployeeTypeAsync(employeeType);

        return Ok();
    }
}