using BlogManagement.Domain.Entities.ArticleCategories;
using BlogManagement.Domain.Entities.Articles;
using BlogManagement.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Persistence.Context;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        
    }
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    public DbSet<Article> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ArticleCategoryConfiguration).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}
