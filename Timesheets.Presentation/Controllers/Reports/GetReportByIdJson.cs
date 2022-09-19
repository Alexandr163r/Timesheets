using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Presentation.Models.ReportCard;

namespace Timesheets.Presentation.Controllers.Reports;

public class GetReportByIdJson : ReportsBase
{
    private readonly IReportService _service;

    private readonly IMapper _mapper;

    private readonly IReportServiceValidator _validator;

    public GetReportByIdJson(IReportService service, IMapper mapper, IReportServiceValidator validator)
    {
        _service = service;
        _mapper = mapper;
        _validator = validator;
    }

   
    [HttpGet("[area]/Json/{id:guid}")]
    public async Task<IActionResult> GetRepoerById(Guid id)
    {
        var validId = await _validator.ExistByIdAsync(id);

        if (validId == false)
        {
            return BadRequest("Отчета с таким Id не найдено");
        }
        
        if (User.Identity.IsAuthenticated)
        {
            var reportForAdmin = await _service.GetByIdAsync(id);
        
            var responseForAdmin = _mapper.Map<List<ReportCardRequestModel>>(reportForAdmin.Reports);
        
            return Ok(responseForAdmin);
        }

        var reportForEmployee = await _service.GetByIdAsync(id);

        var valid = await _validator.IsDeleted(reportForEmployee);

        if (valid == false)
        {
            return Ok("Ссылка на отчет уже использовалась");
        }
        
        var responseForEmployee = _mapper.Map<List<ReportCardRequestModel>>(reportForEmployee.Reports);

        await _service.IsDeleteReportAsync(reportForEmployee);

        return Ok(responseForEmployee);
    }
}