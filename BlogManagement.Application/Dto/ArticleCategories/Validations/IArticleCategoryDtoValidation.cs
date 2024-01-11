using BlogManagement.Application.Common.Dto;
using FluentValidation;

namespace BlogManagement.Application.Dto.ArticleCategories.Validations
{
    public class IArticleCategoryDtoValidation : AbstractValidator<IArticleCategoryDto>
    {
        public IArticleCategoryDtoValidation()
        {
            RuleFor(x => x.Title).NotEmpty()
                .WithMessage(ValidationMessage.RequiredMessage);
        }
    }
}
