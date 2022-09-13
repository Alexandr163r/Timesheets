using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.Report;

namespace Timesheets.Presentation.Controllers.Reports;

public class GetReportBySelector : ReportsBase
{
    private readonly IReportService _service;
    
    private readonly IMapper _mapper;

    public GetReportBySelector(IReportService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("[area]/")]
    public async Task<IActionResult> GetBySelector([FromBody] ReportResponseModel model)
    {
        var report = _mapper.Map<ReportCard>(model);
        
        var reports = await _service.GetReportBySelectorAsync(report);
        
        var response = _mapper.Map<List<ReportRequestModel>>(reports);

        return Ok(response);
    }
}