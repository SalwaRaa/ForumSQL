using ForumApplication.Models;
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
       public void Run()
        {
            PrintUsers(_ur);
        }
        private void PrintUser(User user)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.NickName}  ");
        }
        public void PrintUsers(SqliteUserRepository _ur)
        {
            var users = _ur.GetUser();
            foreach (var user in users)
            {
                PrintUser(user);
            }
        }
        public void PrintUserWithId(int id)
        {
            var user = _ur.GetUserById(id);
            PrintUser(user);
        }
    }
}
