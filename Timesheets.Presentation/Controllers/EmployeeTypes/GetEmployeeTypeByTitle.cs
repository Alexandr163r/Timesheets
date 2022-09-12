using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.EmployeeType;

namespace Timesheets.Presentation.Controllers.EmployeeTypes;

public class GetEmployeeTypeByTitle : EmployeeTypeBase
{
    private readonly IEmployeeTypeService _service;

    private readonly IEmployeeTypeServiceValidator _validator;
    
    private readonly IMapper _mapper;

    public GetEmployeeTypeByTitle(IEmployeeTypeService service, IMapper mapper, IEmployeeTypeServiceValidator validator)
    {
        _service = service;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpGet("[area]/{title}")]
    public async Task<IActionResult> GetById(string title)
    {
        var isValid = await _validator.IsValidTitleAsync(title);

        if (!isValid)
        {
            return BadRequest("Должность не найдена");
        }
        
        var employeeType = await _service.GetEmployeeTypeByTitleAsync(title);

        var response = _mapper.Map<EmployeeTypeRequestModel>(employeeType);

        return Ok(response);
    }
}