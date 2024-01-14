using BlogManagement.Application.Common.Dto;

namespace BlogManagement.Application.Dto.Identities.Users;

public class RegisterUserDto : BaseDto<string>, IUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
}
