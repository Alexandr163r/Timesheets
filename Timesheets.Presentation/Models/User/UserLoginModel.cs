using System.ComponentModel.DataAnnotations;

namespace Timesheets.Presentation.Models.User;

public class UserLoginModel
{
    [Required] 
    [EmailAddress] 
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}