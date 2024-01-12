using BlogManagement.Domain.Entities.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Persistence.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable(nameof(Article));
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();

        builder.HasOne(x => x.ArticleCategory)
            .WithMany(x => x.Article)
            .HasForeignKey(x => x.ArticleCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}