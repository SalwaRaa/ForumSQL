using Dapper;
using ForumApplication.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumApplication.Repos
{
    class SqliteThreadRepository
    {
        private const string _connectionString = "Data Source=.\\ForumDatabase.db";

        public List<Thread> GetThreads()
        {
            using var connection = new SqliteConnection(_connectionString);
            var threads = connection.Query<Thread>("SELECT t.ThreadName, t.ThreadText, t.ThreadId, u.NickName As Owner," +
                "COUNT(PostComment) AS PostCount " +
                "FROM Thread AS t " +
                "LEFT JOIN Post AS p ON p.ThreadId = t.ThreadId " +
                "JOIN User AS u ON u.UserId = t.UserId " +
                "GROUP BY t.ThreadId;");


            return threads.ToList();
        }

        public Thread GetThreadById(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "SELECT * FROM thread WHERE ThreadId = @ThreadId ";
            return connection.QuerySingle<Thread>(sql, new { ThreadId = id });
        }

        public void AddThread(Thread thread)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "INSERT INTO thread (ThreadName, ThreadText, UserId) VALUES (@ThreadName, @ThreadText, @UserId) ";
           connection.Execute(sql, thread);
        }
    }
}
