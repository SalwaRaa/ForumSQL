using System;
using Dapper;
namespace ForumApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new SqliteUserRepository();
            repo.PrintVersion();
            PrintUsers(repo);
        }
        static void PrintUsers(SqliteUserRepository repository)
        {
            var users = repository.GetUser();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} {user.NickName} ");
            }

        }
    }
}
