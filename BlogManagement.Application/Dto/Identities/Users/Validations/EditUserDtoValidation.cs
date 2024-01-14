using FluentValidation;

namespace BlogManagement.Application.Dto.Identities.Users.Validations;

public class EditUserDtoValidation : AbstractValidator<EditUserDto>
{
    public EditUserDtoValidation()
    {
        Include(new IUserDtoValidation());
    }
}