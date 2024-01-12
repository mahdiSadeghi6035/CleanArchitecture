using BlogManagement.Application.Common.Dto;

namespace BlogManagement.Application.Dto.Articles;

public class ListArticleDto : BaseDto<long>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ArticleCategoryTitle { get; set; }
}
