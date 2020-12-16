using System;
using System.Collections.Generic;
using System.Text;

namespace ForumApplication.Models
{
   public class User
    {
        public int UserId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();

        //public List<ForumUser> ForumUser { get; set; }
    }
}
