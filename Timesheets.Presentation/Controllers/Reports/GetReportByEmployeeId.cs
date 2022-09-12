using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.Report;

namespace Timesheets.Presentation.Controllers.Reports;

public class GetReportByEmployeeId : ReportsBase
{
    private readonly IReportService _service;
    
    private readonly IMapper _mapper;

    public GetReportByEmployeeId(IReportService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("[area]/{id:guid}")]
    public async Task<IActionResult> GetByEmployeeId(Guid id)
    {
        var reports = await _service.GetReportByIdAsync(id);
        
        var response = _mapper.Map<List<ReportRequestModel>>(reports);

        return Ok(response);
    }
}