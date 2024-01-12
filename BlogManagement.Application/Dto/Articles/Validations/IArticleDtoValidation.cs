using BlogManagement.Application.Common.Dto;
using FluentValidation;

namespace BlogManagement.Application.Dto.Articles.Validations;

public class IArticleDtoValidation : AbstractValidator<IArticleDto>
{
    public IArticleDtoValidation()
    {
        RuleFor(x => x.Title).NotEmpty()
            .WithMessage(ValidationMessage.RequiredMessage);

        RuleFor(x => x.Description).NotEmpty()
            .WithMessage(ValidationMessage.RequiredMessage);

        RuleFor(x => x.ArticleCategoryId).NotEmpty()
            .WithMessage(ValidationMessage.RequiredMessage);
    }
}
