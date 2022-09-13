namespace Timesheets.DAL.Settings;

public record MSSQLDBSetting(string ConnectionStrings) : DBSetting(ConnectionStrings);