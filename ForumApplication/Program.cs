using System;
using Dapper;
using ForumApplication.Models;

namespace ForumApplication
{
    class Program
    {
        // en instans av klassen, nu slipper jag passa in den i alla metoder
        private static SqliteUserRepository _userRepository;

        static void Main(string[] args)
        {
            _userRepository = new SqliteUserRepository();
            var console = new ConsoleUI();
            console.Run();
        }

    }
}
