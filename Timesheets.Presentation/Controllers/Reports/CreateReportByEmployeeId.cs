using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.Report;

namespace Timesheets.Presentation.Controllers.Reports;

public class CreateReportByEmployeeId : ReportsBase
{
    private readonly IReportService _service;

    public CreateReportByEmployeeId(IReportService service)
    {
        _service = service;
    }

    [HttpGet("[area]/{id:guid}")]
    public async Task<IActionResult> CreatebyEmployeeId(Guid id)
    {
        var reportId = await _service.CreateReportByEmployeeId(id);

        var response = new LinkReportModel()
        {
            Json = $"http://localhost:5000/Report/Json/{reportId}",
            
            Excel = $"http://localhost:5000/Report/Excel/{reportId}"
        };

        return Ok(response);
    }
}