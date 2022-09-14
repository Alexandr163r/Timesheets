using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Presentation.Controllers.Reports;

public class GetReportByIdExcel : ReportsBase
{
    private readonly IReportService _reportService;

    private readonly IGenerateExcelService _excelService;


    public GetReportByIdExcel(IReportService reportService, IGenerateExcelService excelService)
    {
        _reportService = reportService;
        _excelService = excelService;
    }

    [HttpGet("[area]/{id:guid}/Excel")]
    public async Task<IActionResult> GetRepoerById(Guid id)
    {
        var report = await _reportService.GetByIdAsync(id);

        var excel = await _excelService.ConvertToExcelAsync(report.Reports);

        return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Отчет.xlsx");
    }
}