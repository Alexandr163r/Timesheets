namespace Timesheets.Presentation.Models.JWT;

public class JWTResponseModel
{
    public JWT Token { get; set; } = new();

    public class JWT
    {
        public string Token { get; set; } = string.Empty;

        public DateTime ExpiredAt { get; set; }
    }
}
