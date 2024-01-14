using FluentValidation;

namespace BlogManagement.Application.Dto.Articles.Validations;

public class EditArticleDtoValidation : AbstractValidator<EditArticleDto>
{
    public EditArticleDtoValidation()
    {
        Include(new IArticleDtoValidation());
        RuleFor(x => x.Id).NotNull();
    }
}