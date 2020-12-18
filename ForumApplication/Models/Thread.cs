using System;
using System.Collections.Generic;
using System.Text;

namespace ForumApplication.Models
{
    public class Thread
    {
        private int _threadId = -1;
        public int ThreadId
        {
            get { return _threadId; }
            set { if (_threadId == -1) _threadId = value; }
        }
        public string ThreadName { get; set; }

        public string ThreadText { get; set; }

        public int UserId { get; set; }

        public string Owner { get; set; }

        public int PostCount { get; set; }
    }
}

