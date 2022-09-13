using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;

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
        

        return Ok(reportId.ToString());
    }
}