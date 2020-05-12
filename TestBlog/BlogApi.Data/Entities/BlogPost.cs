using System;

namespace BlogApi.Data.Entities
{
    public class BlogPost
    {
        public int PostId { get; set; }
        public string Creator { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Dt { get; set; }
    }
}
