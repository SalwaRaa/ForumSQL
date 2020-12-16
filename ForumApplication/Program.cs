using System;
using Dapper;
namespace ForumApplication
{
    class Program
    {
        // en instans av klassen, nu slipper jag passa in den i alla metoder
        private static SqliteUserRepository _userRepository;

        static void Main(string[] args)
        {
            _userRepository = new SqliteUserRepository();
            _userRepository.PrintVersion();
            PrintUsers();
            PrintUserWithId(1);
        }

        private static void PrintUser(User user)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.NickName}  ");
        }
       public static void PrintUsers()
        {
            var users = _userRepository.GetUser();
            foreach (var user in users)
            {
                PrintUser(user);
            }
        }
       public static void PrintUserWithId(int id)
        {
            var user = _userRepository.GetUserById(id);
            PrintUser(user);
        }
    }
}
