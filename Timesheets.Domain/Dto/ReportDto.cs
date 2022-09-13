using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Dto;

public class ReportDto : BaseId
{
    public string Title { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    
    public string Surname { get; set; } = string.Empty;
    
    public DateTime StartOfWorkDay { get; set; }
    
    public DateTime EndOfWorkDay { get; set; }
    
    public TimeSpan WorkTime { get; set; }
}