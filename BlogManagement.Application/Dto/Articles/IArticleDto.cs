using BlogManagement.Application.Dto.ArticleCategories;

namespace BlogManagement.Application.Dto.Articles;

public interface IArticleDto 
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long ArticleCategoryId { get; set; }
}
