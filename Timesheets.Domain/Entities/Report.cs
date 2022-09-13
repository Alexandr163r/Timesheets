namespace Timesheets.Domain.Entities;

public class Report : BaseId
{
    public List<ReportCard> Reports { get; set; } = new();

    public bool IsDeleted { get; set; } = false;

    public bool IsDawnloaded { get; set; } = false;
}