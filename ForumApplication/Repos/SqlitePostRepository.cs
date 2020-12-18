using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Dapper;
using ForumApplication.Models;
using System.Linq;

namespace ForumApplication.Repos
{
    class SqlitePostRepository
    {
        private const string _connectionString = "Data Source=.\\ForumDatabase.db";

        public Post GetPostById(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "SELECT * FROM Post WHERE PostId = @PostId";
            return connection.QuerySingle<Post>(sql, new { PostId = id });
        }

        public void AddPost(Post post)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "INSERT INTO post (ThreadId, PostComment, UserID) VALUES (@ThreadId, @PostComment, @UserId);";
            connection.Execute(sql, post);
        }

        public List<Post> GetPostsFromThread(Thread thread)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "SELECT * FROM post AS p " +
            " INNER JOIN User AS u ON (u.UserId = p.UserId)" +
            " WHERE p.ThreadId = @ThreadId;";

            var posts = connection.Query<Post, User, Post>(sql, (post, user) =>
            {
                //tilldelar User i tabellen med post.user
                post.User = user;
                return post;
            },
            thread,
            splitOn: "UserId");
            return posts.ToList();
        }

        public void DeletePost(Post post)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "DELETE FROM post WHERE PostId = @PostId;";
            connection.Execute(sql, post);
        }

        public void UpdatePost(Post post)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "UPDATE post SET PostComment = @PostComment WHERE PostId = @PostId;";
            connection.Execute(sql, post);
        }

    }
}