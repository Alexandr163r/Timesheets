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

    public async Task<Guid> CreateReportByEmployeeId(Guid id)
    {
        var reportCards = await _repository.GetReportCardByIdAsync(id);

        var report = await _repository.CreateReportAsync(reportCards);
        
        return report;
    }

    public async Task<Guid> CreateReportBySelectorAsync(ReportCard reportCard)
    {
        var reportCards = await _repository.GetReportCardBySelectorAsync(reportCard);

        var report = await _repository.CreateReportAsync(reportCards);
        
        return report;
    }

    public async Task IsDeleteReportAsync(Report report)
    {
        await _repository.IsDeleteReportAsync(report);
    }

    public async Task IsDownloadedReportAsync(Report report)
    {
        await _repository.IsDownloadedReportAsync(report);
    }

    public async Task<Report> GetByIdAsync(Guid id)
    {
        var report = await _repository.GetByIdAsync(id);

        return report;
    }

    public async Task<bool> ExistByIdAsync(Guid id)
    {
        var exist = await _repository.ExistByIdAsync(id);

        return exist;
    }
}