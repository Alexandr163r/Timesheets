using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.Report;
using Timesheets.Presentation.Models.ReportCard;

namespace Timesheets.Presentation.Controllers.Reports;

public class CreateReportBySelector : ReportsBase
{
    private readonly IReportService _service;
    
    private readonly IMapper _mapper;

    public CreateReportBySelector(IReportService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [Authorize(AuthenticationSchemes = "JWT_OR_COOKIE")]
    [HttpPost("[area]/")]
    public async Task<IActionResult> CreateBySelector([FromBody] ReportCardResponseModel model)
    {
        var reportCard = _mapper.Map<ReportCard>(model);
        
        var reportId = await _service.CreateReportBySelectorAsync(reportCard);
        
        var response = new LinkReportModel(reportId);

        return Ok(response);
    }
}