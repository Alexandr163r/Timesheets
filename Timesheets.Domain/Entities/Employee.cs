namespace Timesheets.Domain.Entities;

// ReSharper disable once ClassNeverInstantiated.Global
public class Employee : BaseId
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;
    
    public Guid EmployeeTypeId { get; set; } 

    public virtual EmployeeType EmployeeType { get; set; }

    public List<TimeSheet> TimeSheets { get; set; } = new();
}