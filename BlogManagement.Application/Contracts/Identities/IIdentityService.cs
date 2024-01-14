using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Dto.Identities.Users;

namespace BlogManagement.Application.Contracts.Identities;

public interface IIdentityService
{
    Task<OperationResult> Register(RegisterUserDto registerUserDto);
    Task<(OperationResult result, string token)> Login(LoginUserDto loginUserDto);
}
