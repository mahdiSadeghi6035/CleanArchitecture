using BlogManagement.Application.Common.Contracts.Persistence;
using BlogManagement.Domain.Entities.ArticleCategories;

namespace BlogManagement.Application.Contracts.Persistence;

public interface IArticleCategoryRepository : IGenericRepository<long, ArticleCategory>
{ 
}
