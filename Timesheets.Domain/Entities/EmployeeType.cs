namespace Timesheets.Domain.Entities;

public class EmployeeType : BaseId
{
    public string Title { get; set; } = string.Empty;

    public List<Employee> Employees { get; set; } = new();
}