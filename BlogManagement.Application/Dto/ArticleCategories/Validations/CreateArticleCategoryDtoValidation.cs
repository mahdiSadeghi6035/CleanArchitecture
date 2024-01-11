using FluentValidation;

namespace BlogManagement.Application.Dto.ArticleCategories.Validations
{
    public class CreateArticleCategoryDtoValidation : AbstractValidator<CreateArticleCategoryDto>
    {
        public CreateArticleCategoryDtoValidation()
        {
            Include(new IArticleCategoryDtoValidation());
        }
    }
}
