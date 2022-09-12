using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.Employee;

namespace Timesheets.Presentation.Controllers.Employees;

public class GetAllEmployee : EmployeeBase
{
    private readonly IEmployeeService _service;

    private readonly IMapper _mapper;
    
    public GetAllEmployee(IEmployeeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("[area]/All")]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _service.GetAllEmployeeAsync();
        
        var response = _mapper.Map<List<EmployeeRequestModel>>(employees);

        return Ok(response);
    }
}