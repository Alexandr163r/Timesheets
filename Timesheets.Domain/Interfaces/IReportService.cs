using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IReportService
{
    public Task<Guid> CreateReportByEmployeeId(Guid id);

    public Task<Guid> CreateReportBySelectorAsync(ReportCard reportCard);
    
    public Task IsDeleteReportAsync(Report report);

    public Task IsDownloadedReportAsync(Report report);

    public Task<Report> GetByIdAsync(Guid id);

    public Task<bool> ExistByIdAsync(Guid id);
}