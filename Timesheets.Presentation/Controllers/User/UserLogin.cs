using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Timesheets.DAL.Entity;
using Timesheets.Presentation.Models.JWT;
using Timesheets.Presentation.Models.User;
using Timesheets.Presentation.Settings;

namespace Timesheets.Presentation.Controllers.User;

public class UserLogin : UserBase
{
    private readonly IMapper _mapper;

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly SignInManager<ApplicationUser> _signInManager;

    private readonly JWTSetting _jwtSetting;

    public UserLogin(IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSetting> jwtSetting)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSetting = jwtSetting.Value;
    }

    [HttpPost("[Area]/Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginModel userModel)
    {
        var user = await _userManager.FindByEmailAsync(userModel.Email);
        
        if (user == null)
        {
            return BadRequest("пользователь не найден");
        }
        
        var passwordSignInResult = await _signInManager.PasswordSignInAsync(user, userModel.Password, false,false);

        if (!passwordSignInResult.Succeeded)
        {
            return this.BadRequest("PasswordNotValid");
        }
        
        var claims = this.GetClaims(userModel.Email);
        var jwt = this.GetJWT(claims);
        var result = new JWTResponseModel()
        {
            Token = jwt,
        };

        return Ok(result);
    }
    
    private List<Claim> GetClaims(string email)
        => new List<Claim>
        {
            new Claim(ClaimTypes.Email, email),
        };

    private JWTResponseModel.JWT GetJWT(List<Claim> claims)
    {
        var expiredAt = DateTime.Now.Add(_jwtSetting.ExpiredAt);
        var jwt = new JwtSecurityToken(
            issuer: _jwtSetting.Issuer,
            audience: _jwtSetting.Audience,
            claims: claims,
            expires: expiredAt,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key)), SecurityAlgorithms.HmacSha256));

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new()
        {
            Token = token,
            ExpiredAt = expiredAt,
        };
    }
}