using BlogManagement.Domain.Entities.ArticleCategories;
using BlogManagement.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Persistence.Context;

public class BlogContext : DbContext
{
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ArticleCategoryConfiguration).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}
