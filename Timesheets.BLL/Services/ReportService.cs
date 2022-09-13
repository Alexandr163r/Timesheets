using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _repository;

    public ReportService(IReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ReportCard>> GetReportByIdAsync(Guid id)
    {
        var reports = await _repository.GetReportByIdAsync(id);

        return reports;
    }

    public async Task<List<ReportCard>> GetReportBySelectorAsync(ReportCard reportCard)
    {
        var reports = await _repository.GetReportBySelectorAsync(reportCard);

        return reports;
    }
}