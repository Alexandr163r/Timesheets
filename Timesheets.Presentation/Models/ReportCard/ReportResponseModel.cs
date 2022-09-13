namespace Timesheets.Presentation.Models.ReportCard;

public class ReportCardResponseModel
{
    public string? Name { get; set; } 
    
    public string? Surname { get; set; }
    
    public DateTime StartOfWorkDay { get; set; }
    
    public DateTime EndOfWorkDay { get; set; }
}