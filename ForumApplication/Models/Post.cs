using System;
using System.Collections.Generic;
using System.Text;

namespace ForumApplication.Models
{
    public class Post
    {
        public int PostId { get; }
        public string PostComment { get; set; }
        public int UserId { get; set; }
        public int ThreadId { get; set; }
        public User User { get; set; }
        public Thread Thread { get; set; }
    }
}
