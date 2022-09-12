namespace Timesheets.Presentation.Models.Report;

public class ReportResponseModel
{
    public string? Name { get; set; } 
    
    public string? Surname { get; set; }
    
    public DateTime StartOfWorkDay { get; set; }
    
    public DateTime EndOfWorkDay { get; set; }
}