using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Domain.Entities.ArticleCategories;
using BlogManagement.Persistence.Context;
using HR.Management.Persistence.Repository;

namespace BlogManagement.Persistence.Repository
{
    public class ArticleCategoryRepository : GenericRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryRepository(BlogContext context) : base(context)
        {
            _blogContext = context;
        }
    }
}
