using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace ForumApplication
{
   public class User
    {
        public int UserId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public List<ForumUser> ForumUser { get; set; }
    }
}
