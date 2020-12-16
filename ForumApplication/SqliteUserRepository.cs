using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ForumApplication
{
    class SqliteUserRepository
    {
        //öppna forumdata där du står nu 
        private const string _connectionString = "Data Source=.\\ForumDatabase.db";

        public void PrintVersion()
        {
           using var connection = new SqliteConnection(_connectionString);
           System.Console.WriteLine(connection.ServerVersion);
        }

        public List<User> GetUser()
        {
                using var connection = new SqliteConnection(_connectionString);
                // på connectionen vill jag utföra en query. Förväntar mig att få tillbaka user
                var users = connection.Query<User>("SELECT * FROM user");

                //Vi vill oftast arbeta med listor oftast för att kunna göra filtreringar. 
                //konverterar users till en lista då users är en inumerble
                return users.ToList();  
        }
    }
}
