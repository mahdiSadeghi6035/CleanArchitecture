using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Contracts.Identities;
using BlogManagement.Application.Dto.Identities.Users;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public AuthController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<OperationResult>> Register(RegisterUserDto createUserDto)
    {
        var result = await _identityService.Register(createUserDto);
        return result.IsSucceeded ? Ok(result.Message) : BadRequest(result.Message);
    }
    [HttpPost("login")]
    public async Task<ActionResult<OperationResult>> Login(LoginUserDto loginUserDto)
    {
        var result = await _identityService.Login(loginUserDto);

        return result.result.IsSucceeded ? Ok(result.token) : BadRequest(result.result.Message);
    }
}
