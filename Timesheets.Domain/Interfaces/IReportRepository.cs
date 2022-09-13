using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IReportRepository
{
    public Task<List<ReportCard>> GetReportByIdAsync(Guid id);

    public Task<List<ReportCard>> GetReportBySelectorAsync(ReportCard reportCard);
}