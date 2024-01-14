using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Contracts.Identities;
using BlogManagement.Application.Dto.Identities.Users;
using BlogManagement.Application.Dto.Identities.Users.Validations;
using BlogManagement.Application.Model;
using BlogManagement.Identity.Common.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogManagement.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JWTSettingModel _jWTSettingModel;

    public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<JWTSettingModel> jWTSettingModel)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jWTSettingModel = jWTSettingModel.Value;
    }

    public async Task<OperationResult> Register(RegisterUserDto registerUserDto)
    {
        var validation = new RegisterUserDtoValidation();
        var validationResult = await validation.ValidateAsync(registerUserDto);
        if (!validationResult.IsValid)
            return OperationResult.Failed(validationResult.Errors[0].ErrorMessage);

        var user = new IdentityUser()
        {
            UserName = registerUserDto.UserName,
            Email = registerUserDto.Email,
            EmailConfirmed = true
        };
        var result = await _userManager.CreateAsync(user, registerUserDto.Password);

        return result.ToResult();
    }

    public async Task<(OperationResult result, string token)> Login(LoginUserDto loginUserDto)
    {
        var validation = new LoginUserDtoValidation();
        var validationResult = await validation.ValidateAsync(loginUserDto);
        if (!validationResult.IsValid)
            return (OperationResult.Failed(validationResult.Errors[0].ErrorMessage), string.Empty);

        var user = await _userManager.FindByNameAsync(loginUserDto.UserName);

        var loginUser = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, true, true);
        var result = loginUser.ToResult();

        string token = result.IsSucceeded ? GenericToken(user) : string.Empty;

        return (result, token);
    }
    private string GenericToken(IdentityUser user)
    {
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.ASCII.GetBytes(_jWTSettingModel.SecretKey));

        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var claim = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        JwtSecurityToken jwtSecurityToken =
            new(_jWTSettingModel.Issuer, _jWTSettingModel.Audience, claim, DateTime.Now, DateTime.Now.AddDays(_jWTSettingModel.DurationDay), signingCredentials);

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return token;
    }
}
