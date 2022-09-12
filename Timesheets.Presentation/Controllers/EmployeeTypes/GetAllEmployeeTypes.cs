using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.EmployeeType;

namespace Timesheets.Presentation.Controllers.EmployeeTypes;

public class GetAllEmployeeTypes : EmployeeTypeBase
{
    private readonly IEmployeeTypeService _service;
    
    private readonly IMapper _mapper;

    public GetAllEmployeeTypes(IEmployeeTypeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("[area]/All")]
    public async Task<IActionResult> GetAll()
    {
        var employeeTypes = await _service.GetAllEmployeeTypeAsync();

        var response = _mapper.Map<List<EmployeeTypeRequestModel>>(employeeTypes);

        return Ok(response);
    }
}