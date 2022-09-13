using Timesheets.Domain.Dto;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _repository;

    public ReportService(IReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ReportDto>> GetReportByIdAsync(Guid id)
    {
        var reports = await _repository.GetReportByIdAsync(id);

        return reports;
    }

    public async Task<List<ReportDto>> GetReportBySelectorAsync(ReportDto reportDto)
    {
        var reports = await _repository.GetReportBySelectorAsync(reportDto);

        return reports;
    }
}