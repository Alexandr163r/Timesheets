using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces;

public interface IGenerateExcelService
{
    public Task<byte[]> ConvertToExcelAsync(List<ReportCard> reportCards);
}