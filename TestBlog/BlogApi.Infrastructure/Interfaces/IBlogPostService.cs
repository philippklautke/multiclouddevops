using BlogApi.Infrastructure.Dtos;
using BlogApi.Infrastructure.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Interfaces
{
    public interface IBlogPostService
    {
        public Task<List<BlogPostDto>> GetAllBlogPostsAsync();
        public Task<BlogPostDto> GetBlogPostById(int id);
        public Task<BlogPostDto> SaveBlogPost(int id, BlogPostResource resource);
        public Task<BlogPostDto> CreateBlogPost(BlogPostResource resource);
        public Task<BlogPostDto> DeleteBlogPostById(int id);
    }
}
