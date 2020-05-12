using BlogApi.Data.Entities;
using BlogApi.Infrastructure.Dtos;
using BlogApi.Infrastructure.Resources;

namespace BlogApi.Data.Mapper
{
    public static class BlogPostMapper
    {
        public static BlogPostDto MapToDto(BlogPost blogPost)
        {
            if (blogPost == null) return null;
            return new BlogPostDto()
            {
                PostId = blogPost.PostId,
                Creator = blogPost.Creator,
                Title = blogPost.Title,
                Body = blogPost.Body,
                Dt = blogPost.Dt
            };
        }
        public static BlogPost MapToDb(BlogPostResource resource)
        {
            if (resource == null) return null;
            return new BlogPost()
            {
                Creator = resource.Creator,
                Title = resource.Title,
                Body = resource.Body,
                Dt = resource.Dt
            };
        }
    }
}
