using BlogManagement.Application.Common.Dto;

namespace BlogManagement.Application.Dto.ArticleCategories;

public class CreateArticleCategoryDto : BaseDto<long>, IArticleCategoryDto
{
    public string Title { get; set; }
}
