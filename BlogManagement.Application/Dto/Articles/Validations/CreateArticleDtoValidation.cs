using FluentValidation;

namespace BlogManagement.Application.Dto.Articles.Validations;

public class CreateArticleDtoValidation : AbstractValidator<CreateArticleDto>
{
    public CreateArticleDtoValidation()
    {
        Include(new IArticleDtoValidation());
    }
}