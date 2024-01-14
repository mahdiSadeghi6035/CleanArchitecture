using BlogManagement.Application.Common.Dto;
using FluentValidation;

namespace BlogManagement.Application.Dto.Articles.Validations;

public class IArticleDtoValidation : AbstractValidator<IArticleDto>
{
    public IArticleDtoValidation()
    {
        RuleFor(x => x.Title).NotEmpty().Length(5, 150);

        RuleFor(x => x.Description).NotEmpty();

        RuleFor(x => x.ArticleCategoryId).NotNull();
    }
}
