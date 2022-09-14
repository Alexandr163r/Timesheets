using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IGenerateExcelService
{
    public Task<MemoryStream> ConvertToExcelAsync(List<ReportCard> reportCards);
}