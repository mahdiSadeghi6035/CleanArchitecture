using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Domain.Entities.ArticleCategories;
using BlogManagement.Persistence.Context;
using HR.Management.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Persistence.Repository;

public class ArticleCategoryRepository : GenericRepository<long, ArticleCategory>, IArticleCategoryRepository
{
    private readonly BlogContext _blogContext;

    public ArticleCategoryRepository(BlogContext blogContext) : base(blogContext)
    {
        _blogContext = blogContext;
    }

    public async Task<IReadOnlyList<ArticleCategory>> GetAllWithArticle()
    {
      return await _blogContext.ArticleCategories.Include(x => x.Article)
            .ToListAsync();
    }
}
