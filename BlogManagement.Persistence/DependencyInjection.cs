using BlogManagement.Application.Common.Contracts.Persistence;
using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Persistence.Context;
using BlogManagement.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        string connection = configuration.GetConnectionString("BlogDb");

        services.AddDbContext<BlogContext>(x => x.UseSqlServer(connection));
        services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
    }
}
