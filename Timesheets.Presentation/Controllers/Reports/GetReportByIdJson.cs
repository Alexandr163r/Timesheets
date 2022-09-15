using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.ReportCard;

namespace Timesheets.Presentation.Controllers.Reports;

public class GetReportByIdJson : ReportsBase
{
    private readonly IReportService _service;

    private readonly IMapper _mapper; 
    

    public GetReportByIdJson(IReportService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("[area]/Json/{id:guid}")]
    public async Task<IActionResult> GetRepoerById(Guid id)
    {
        var report = await _service.GetByIdAsync(id);

        var response = _mapper.Map<List<ReportCardRequestModel>>(report.Reports);
        
        return Ok(response);
    }
}