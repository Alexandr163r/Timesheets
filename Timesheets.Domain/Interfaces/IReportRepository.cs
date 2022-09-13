using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IReportRepository
{
    public Task<List<ReportCard>> GetReportCardByIdAsync(Guid id);

    public Task<List<ReportCard>> GetReportCardBySelectorAsync(ReportCard reportCard);

    public Task<Guid> CreateReportAsync(List<ReportCard> reportCards);

    public Task IsDeleteReportAsync(Report report);

    public Task IsDownloadedReportAsync(Report report);

    public Task<Report> GetByIdAsync(Guid id);

    public Task<bool> ExistByIdAsync(Guid id);
}