namespace Timesheets.Presentation.Models.Report;

public class LinkReportModel
{
    private readonly Guid _id;

    public LinkReportModel(Guid id)
    {
        _id = id;

        Json = $"http://localhost:5000/Report/Json/{_id}";
        Excel = $"http://localhost:5000/Report/Excel/{_id}";
    }
    
    public string Json { get; }

    public string Excel { get; }
}