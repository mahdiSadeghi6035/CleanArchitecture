using BlogManagement.Application.Common.Dto;

namespace BlogManagement.Application.Dto.ArticleCategories;

public class EditArticleCategoryDto : BaseDto<long>, IArticleCategoryDto
{
    public string Title { get; set; }
}
