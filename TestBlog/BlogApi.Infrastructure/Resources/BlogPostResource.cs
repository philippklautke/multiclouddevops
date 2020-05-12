using System;

namespace BlogApi.Infrastructure.Resources
{
    public class BlogPostResource
    {
        public string Creator { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Dt { get; set; }
    }
}
