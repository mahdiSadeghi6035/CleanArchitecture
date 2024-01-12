using BlogManagement.Domain.Common.Entity;
using BlogManagement.Domain.Entities.Articles;

namespace BlogManagement.Domain.Entities.ArticleCategories;

public class ArticleCategory : BaseEntity<long>
{
    public string Title { get; set; }
    public List<Article> Article { get; set; }
    public ArticleCategory()
    {
        Article = new List<Article>();
    }
}
