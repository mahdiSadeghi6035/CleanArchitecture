using BlogManagement.Application.Common.Dto;
using FluentValidation;

namespace BlogManagement.Application.Dto.ArticleCategories.Validations
{
    public class EditArticleCategoryDtoValidation : AbstractValidator<EditArticleCategoryDto>
    {
        public EditArticleCategoryDtoValidation()
        {
            Include(new IArticleCategoryDtoValidation());

            RuleFor(x => x.Id).NotNull();
        }
    }
}
