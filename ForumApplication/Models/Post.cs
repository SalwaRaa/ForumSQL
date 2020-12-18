using System;
using System.Collections.Generic;
using System.Text;

namespace ForumApplication.Models
{
    public class Post
    {
        private int _postId = -1;
        public int PostId
        {
            get { return _postId; }
            set { if (_postId == -1) _postId = value; }
        }
        public string PostComment { get; set; }

        public int UserId { get; set; }

        public int ThreadId { get; set; }

        public User User { get; set; }
    }
}