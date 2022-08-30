namespace Timesheets.Domain.Entities;

public class TimeSheet : BaseId
{
    public DateTime StartOfWorkDay { get; set; }

    public DateTime EndOfWorkDay { get; set; }

    public TimeSpan WorkingTime { get; set; }

    public Guid EmployeeId { get; set; }
}