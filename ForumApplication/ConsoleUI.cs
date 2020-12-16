using ForumApplication.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumApplication
{
    class ConsoleUI
    {   
        private SqliteUserRepository _ur = new SqliteUserRepository();
        private SqliteThreadRepository _tr = new SqliteThreadRepository();
        private SqlitePostRepository _pr = new SqlitePostRepository();   
    }
}
