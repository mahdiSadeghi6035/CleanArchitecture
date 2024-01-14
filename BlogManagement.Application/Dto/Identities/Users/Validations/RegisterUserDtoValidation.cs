using BlogManagement.Application.Common.Dto;
using FluentValidation;

namespace BlogManagement.Application.Dto.Identities.Users.Validations;

public class RegisterUserDtoValidation : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidation()
    {
        Include(new IUserDtoValidation());

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.RePassword)
            .NotEmpty()
            .Equal(x => x.Password);
    }
}
