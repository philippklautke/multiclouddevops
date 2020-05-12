using BlogApi.Data.Entities;
using BlogApi.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data
{
    public class BlogApiContext : DbContext
    {
        public BlogApiContext(DbContextOptions<BlogApiContext> options) : base(options)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogPostConfiguration());
        }
    }
}
