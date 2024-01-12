using BlogManagement.Domain.Common.Entity;
using BlogManagement.Domain.Entities.ArticleCategories;

namespace BlogManagement.Domain.Entities.Articles;

public class Article : BaseEntity<long>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long ArticleCategoryId { get; set; }
    public ArticleCategory  ArticleCategory{ get; set; }
}
