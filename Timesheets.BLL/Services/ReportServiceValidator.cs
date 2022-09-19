using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class ReportServiceValidator : IReportServiceValidator
{
    private readonly IReportRepository _repository;

    public ReportServiceValidator(IReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExistByIdAsync(Guid id)
    {
        var result = await _repository.ExistByIdAsync(id);

        return result;
    }

    public Task<bool> IsDownloaded(Report report)
    {
        if (report.IsDawnloaded == false)
        {
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }

    public Task<bool> IsDeleted(Report report)
    {
        if (report.IsDeleted == false)
        {
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}