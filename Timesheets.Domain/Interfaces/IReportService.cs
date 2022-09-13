using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IReportService
{
    public Task<List<ReportCard>> GetReportByIdAsync(Guid id);

    public Task<List<ReportCard>> GetReportBySelectorAsync(ReportCard reportDto);
}