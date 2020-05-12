using System;

namespace BlogApi.Infrastructure.Dtos
{
    public class BlogPostDto
    {
        public int PostId { get; set; }
        public string Creator { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Dt { get; set; }
    }
}
