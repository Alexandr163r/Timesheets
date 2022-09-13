using Timesheets.Domain.Dto;

namespace Timesheets.Domain.Interfaces;

public interface IReportRepository
{
    public Task<List<ReportDto>> GetReportByIdAsync(Guid id);

    public Task<List<ReportDto>> GetReportBySelectorAsync(ReportDto reportDto);
}