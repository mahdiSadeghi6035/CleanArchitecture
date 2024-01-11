using BlogManagement.Domain.Common.Entity;

namespace BlogManagement.Domain.Entities.ArticleCategories;

public class ArticleCategory : BaseEntity<long>
{
    public string Title { get; set; }
}
