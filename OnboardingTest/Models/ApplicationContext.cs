using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnboardingTest.Models;

public sealed class ApplicationContext: DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Article> Articles { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(CategoryConfigure);
        modelBuilder.Entity<Article>(ArticleConfigure);
    }

    private void CategoryConfigure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(category => category.Id)
            .HasColumnName("id");
        builder.Property(category => category.Name).HasColumnName("name");
    }
    
    private void ArticleConfigure(EntityTypeBuilder<Article> builder)
    {
        builder.Property(article => article.Id).HasColumnName("id");
        builder.Property(article => article.Title).HasColumnName("title");
        builder.Property(article => article.Text).HasColumnName("text");
        builder.Property(article => article.CategoryId).HasColumnName("category_id");
        // builder.Property("CategoryId").HasColumnName("category_id");
        // builder
            // .HasOne(article => article.Category)
            // .WithMany(category => category.Articles);
    }
}