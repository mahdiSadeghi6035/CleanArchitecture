using BlogManagement.Application.Common.Dto;
using FluentValidation;

namespace BlogManagement.Application.Dto.Identities.Users.Validations;

public class IUserDtoValidation : AbstractValidator<IUserDto>
{
    public IUserDtoValidation()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.UserName)
            .NotNull()
            .NotEmpty();
    }
}
