namespace Timesheets.Presentation.Settings;

public class JWTSetting
{
    public string Issuer { get; set; }
    
    public string Audience { get; set; }
    
    public string Key { get; set; }
    
    public TimeSpan ExpiredAt { get; set; }
}