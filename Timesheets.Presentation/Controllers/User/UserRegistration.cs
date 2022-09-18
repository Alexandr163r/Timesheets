using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Entity;
using Timesheets.Presentation.Models.User;

namespace Timesheets.Presentation.Controllers.User;

public class UserRegistration : UserBase
{
    private readonly IMapper _mapper;

    private readonly UserManager<ApplicationUser> _userManager;


    public UserRegistration(IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    
    [HttpPost("[Area]/Registration")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationModel userModel)
    {
        var user = _mapper.Map<ApplicationUser>(userModel);
        
        await _userManager.CreateAsync(user, userModel.Password);

        return Ok();
    }
}