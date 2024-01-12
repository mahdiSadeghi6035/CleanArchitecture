using BlogManagement.Domain.Entities.ArticleCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Persistence.Configurations;

public class ArticleCategoryConfiguration : IEntityTypeConfiguration<ArticleCategory>
{
    public void Configure(EntityTypeBuilder<ArticleCategory> builder)
    {
        builder.ToTable(nameof(ArticleCategory));
        builder.HasKey(x => x.Id);  

        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();

        builder.HasMany(x => x.Article)
            .WithOne(x => x.ArticleCategory)
            .HasForeignKey(x => x.ArticleCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
