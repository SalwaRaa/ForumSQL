using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace ForumApplication
{
    public class Thread
    {
        public int ThreadId { get; set; }  
        public string ThreadName { get; set; }
        public string ThreadText { get; set; }
        public int UserId { get; set; }
    }
}
