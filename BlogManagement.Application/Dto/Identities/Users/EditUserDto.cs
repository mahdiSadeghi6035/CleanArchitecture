using BlogManagement.Application.Common.Dto;

namespace BlogManagement.Application.Dto.Identities.Users;

public class EditUserDto : BaseDto<string>, IUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
}