namespace Timesheets.Domain.Entities;

public abstract class Employee : BaseId
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;
    
    public Guid EmployeeTypeId { get; set; }
}