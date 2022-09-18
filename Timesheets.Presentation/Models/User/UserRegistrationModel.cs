using System.ComponentModel.DataAnnotations;

namespace Timesheets.Presentation.Models.User;

public class UserRegistrationModel
{
    [Required] public string UserName { get; set; } = string.Empty;
    
    [Required] 
    [EmailAddress] 
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;
}