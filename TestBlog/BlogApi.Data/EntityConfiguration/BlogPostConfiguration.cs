using BlogApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.Data.EntityConfiguration
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable("BlogPosts");
            builder.HasKey(c => c.PostId);
            builder.Property(c => c.Creator).IsRequired();
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Body).IsRequired();
            builder.Property(c => c.Dt).IsRequired();
        }
    }
}
