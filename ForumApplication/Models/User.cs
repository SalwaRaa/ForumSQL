using System;
using System.Collections.Generic;
using System.Text;

namespace ForumApplication.Models
{
    public class User
    {
        private int _userId = -1;
        public int UserId
        {
            get { return _userId; }
            set { if (_userId == -1) _userId = value; }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public int Password { get; set; }

    }
}
