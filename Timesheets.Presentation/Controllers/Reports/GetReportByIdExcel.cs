using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Presentation.Controllers.Reports;

public class GetReportByIdExcel : ReportsBase
{
    private readonly IReportService _reportService;

    private readonly IReportServiceValidator _validator;

    private readonly IGenerateExcelService _excelService;


    public GetReportByIdExcel(IReportService reportService, IGenerateExcelService excelService, IReportServiceValidator validator)
    {
        _reportService = reportService;
        _excelService = excelService;
        _validator = validator;
    }
    
    [HttpGet("[area]/Excel/{id:guid}")]
    public async Task<IActionResult> GetRepoerById(Guid id)
    {
        var validId = await _validator.ExistByIdAsync(id);

        if (validId == false)
        {
            return BadRequest("Отчета с таким Id не найдено");
        }

        if (User.Identity.IsAuthenticated)
        {
            var reportForAdmin = await _reportService.GetByIdAsync(id);

            var excel = await _excelService.ConvertToExcelAsync(reportForAdmin.Reports);

            return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Отчет.xlsx");
        }
        
        var reportForEmployee = await _reportService.GetByIdAsync(id);

        var valid = await _validator.IsDownloaded(reportForEmployee);

        if (valid == false)
        {
            return Ok("Ссылка на скачивание отчет уже использовалась");
        }

        await _reportService.IsDownloadedReportAsync(reportForEmployee);
        
        var excelForEmployee = await _excelService.ConvertToExcelAsync(reportForEmployee.Reports);

        return File(excelForEmployee, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Отчет.xlsx");
    }
}