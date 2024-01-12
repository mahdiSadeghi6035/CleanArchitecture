using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Application.Dto.Articles;
using BlogManagement.Domain.Entities.Articles;
using BlogManagement.Persistence.Context;
using HR.Management.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Persistence.Repository;

public class ArticleRepository : GenericRepository<long, Article>, IArticleRepository
{
    private readonly BlogContext _blogContext;

    public ArticleRepository(BlogContext blogContext) : base(blogContext)
    {
        _blogContext = blogContext;
    }

    public async Task<IReadOnlyList<Article>> GetAllWithArticleCategory()
    {
       return await _blogContext.Articles.Include(x => x.ArticleCategory)
            .ToListAsync();
    }
}
