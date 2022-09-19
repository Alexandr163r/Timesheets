using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IReportServiceValidator
{
    public Task<bool> ExistByIdAsync(Guid id);
    
    public Task<bool> IsDownloaded(Report report);

    public Task<bool> IsDeleted(Report report);
}