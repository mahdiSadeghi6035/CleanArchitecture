using BlogManagement.Application.Common.Dto;
using FluentValidation;

namespace BlogManagement.Application.Dto.Identities.Users.Validations;

public class LoginUserDtoValidation : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidation()
    {
        RuleFor(x => x.UserName)
           .NotNull()
           .NotEmpty();

        RuleFor(x => x.Password)
           .NotNull()
           .NotEmpty();
    }
}