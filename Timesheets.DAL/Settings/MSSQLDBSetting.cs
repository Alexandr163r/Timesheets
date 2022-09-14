namespace Timesheets.DAL.Settings;

public record MSSQLDBSetting(string ConnectionStrings) : DBSetting(ConnectionStrings)
{
    public MSSQLDBSetting() : this(ConnectionStrings: string.Empty)
    {
    }
}
