using System.ComponentModel.DataAnnotations;

namespace Timesheets.Presentation.Models.TimeSheet;

public class TimeSheetResponseModel
{
    public DateTime StartOfWorkDay { get; set; }
    
    public DateTime EndOfWorkDay { get; set; }
}