namespace Timesheets.Presentation.Models.TimeSheet;

public class TimeSheetRequestModel
{
    public Guid Id { get; set; }
    
    public DateTime StartOfWorkDay { get; set; }

    public DateTime EndOfWorkDay { get; set; }

    public TimeSpan WorkingTime { get; set; }

    public Guid EmployeeId { get; set; }
}