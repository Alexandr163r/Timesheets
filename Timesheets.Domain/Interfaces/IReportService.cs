using Timesheets.Domain.Dto;

namespace Timesheets.Domain.Interfaces;

public interface IReportService
{
    public Task<List<ReportDto>> GetReportByIdAsync(Guid id);

    public Task<List<ReportDto>> GetReportBySelectorAsync(ReportDto reportDto);
}