using System;
using System.Collections.Generic;
using System.Text;

namespace ForumApplication.Models
{
    class Thread
    {
        public int ThreadId { get; set; }
        public string ThreadName { get; set; }
        public string ThreadText { get; set; }
        public int UserId { get; set; }
        public string Owner { get; set; }
        public int PostCount { get; set; }
    }
}
