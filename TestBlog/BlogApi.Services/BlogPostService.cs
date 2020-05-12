using BlogApi.Data;
using BlogApi.Data.Mapper;
using BlogApi.Infrastructure.Dtos;
using BlogApi.Infrastructure.Interfaces;
using BlogApi.Infrastructure.Resources;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BlogApiContext _context;
        public BlogPostService(BlogApiContext context)
        {
            _context = context;
        }
        public async Task<List<BlogPostDto>> GetAllBlogPostsAsync()
        {
            return (await _context.BlogPosts.ToListAsync()).Select(BlogPostMapper.MapToDto).ToList();
        }
        public async Task<BlogPostDto> GetBlogPostById(int id)
        {
            return BlogPostMapper.MapToDto(await _context.BlogPosts.FirstOrDefaultAsync(c => c.PostId == id));
        }
        public async Task<BlogPostDto> SaveBlogPost(int id, BlogPostResource resource)
        {
            var blogPost = await _context.BlogPosts.FirstOrDefaultAsync(blogPost => blogPost.PostId == id);
            if (blogPost == null)
            {
                return null;
            }
            blogPost.Title = resource.Title;
            blogPost.Body = resource.Body;
            blogPost.Creator = resource.Creator;
            blogPost.Dt = resource.Dt;
            await _context.SaveChangesAsync();
            return BlogPostMapper.MapToDto(blogPost);
        }
        public async Task<BlogPostDto> CreateBlogPost(BlogPostResource resource)
        {
            var blogPost = BlogPostMapper.MapToDb(resource);
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();
            return BlogPostMapper.MapToDto(blogPost);
        }
        public async Task<BlogPostDto> DeleteBlogPostById(int id)
        {
            var blogPost = await _context.BlogPosts.FirstOrDefaultAsync(blogPost => blogPost.PostId == id);
            if (blogPost == null)
            {
                return null;
            }
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
            return BlogPostMapper.MapToDto(blogPost);
        }
        
    }
}
