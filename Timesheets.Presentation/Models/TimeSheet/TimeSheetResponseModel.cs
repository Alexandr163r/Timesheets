using System.ComponentModel.DataAnnotations;

namespace Timesheets.Presentation.Models.TimeSheet;

public class TimeSheetResponseModel
{
    [DataType(DataType.Date)]
    public DateTime StartOfWorkDay { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime EndOfWorkDay { get; set; }
}