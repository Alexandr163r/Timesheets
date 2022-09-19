using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.Report;

namespace Timesheets.Presentation.Controllers.Reports;

public class CreateReportByEmployeeId : ReportsBase
{
    private readonly IReportService _service;
    private readonly IEmployeeServiceValidator _validator;

    public CreateReportByEmployeeId(IReportService service, IEmployeeServiceValidator validator)
    {
        _service = service;
        _validator = validator;
    }
    
    [Authorize(AuthenticationSchemes = "JWT_OR_COOKIE")]
    [HttpGet("[area]/{id:guid}")]
    public async Task<IActionResult> CreatebyEmployeeId(Guid id)
    {
        var validId = await _validator.IsValidIdAsync(id);

        if (!validId)
        {
            return Ok("Работника с таким Id не найдено");
        }
        
        var reportId = await _service.CreateReportByEmployeeId(id);

        var response = new LinkReportModel()
        {
            Json = $"http://localhost:5000/Report/Json/{reportId}",
            
            Excel = $"http://localhost:5000/Report/Excel/{reportId}"
        };

        return Ok(response);
    }
}