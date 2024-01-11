using BlogManagement.Application.Common.Dto;

namespace BlogManagement.Application.Dto.ArticleCategories;

public class ListArticleCategoryDto : BaseDto<long>, IArticleCategoryDto
{
    public string Title { get; set; }
    public int Count { get; set; }
}
