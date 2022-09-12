namespace Timesheets.Presentation.Models.EmployeeType;

public class EmployeeTypeRequestModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = String.Empty;
}