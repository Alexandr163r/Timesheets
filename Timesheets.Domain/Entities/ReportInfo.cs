using Timesheets.Domain.Dto;

namespace Timesheets.Domain.Entities;

public class ReportInfo : BaseId
{
    public List<ReportDto> Reports { get; set; } = new();

    public bool IsDeleted { get; set; } = false;

    public bool IsDawnloaded { get; set; } = false;
}