using BlogManagement.Application.Common.Contracts.Persistence;
using BlogManagement.Application.Dto.Articles;
using BlogManagement.Domain.Entities.Articles;

namespace BlogManagement.Application.Contracts.Persistence;

public interface IArticleRepository : IGenericRepository<long, Article>
{
    Task<IReadOnlyList<Article>> GetAllWithArticleCategory();
}
