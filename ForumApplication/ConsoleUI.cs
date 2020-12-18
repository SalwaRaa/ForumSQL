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
        private User _user;

        private bool Running = true;
        private bool LogInOkay = false;
        public void Run()
        {
            while (Running)
            {
                if (!LogInOkay)
                    Login();
                else
                    ForumMenu();
            }
        }
        private void ForumMenu()
        {
            Console.Clear();
            Console.WriteLine("--WELCOME TO THE FORUM--");
            Console.WriteLine("Please choose your command by typing a number ranging between 0 - 6");
            Console.WriteLine("1): List all threads");
            Console.WriteLine("2): List all posts in a specific thread");
            Console.WriteLine("3): Replay with a post in a specific thread");
            Console.WriteLine("4): Create a thread");
            Console.WriteLine("5): Edit a post");
            Console.WriteLine("6): Remove a post");
            Console.WriteLine("0): Exit the app");

            var command = Validate.OnlyNumbers(Console.ReadLine());
            switch (command)
            {
                
                case "1":
                    ListThreads(_tr);
                    break;
                case "2":
                    ListPostInThread(_pr, _tr);
                    break;
                case "3":
                    AddPostInThread();
                    break;
                case "4":
                    AddThread();
                    break;
                case "5":
                    EditPost(_pr);
                    break;
                case "6":
                    DeletePost(_pr);
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        private User Login()
        {
            var users = _ur.GetUser();
            Console.WriteLine("Please enter the user-ID: ");
            var tmpUserId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your password");

            var tmpPassword = int.Parse(Console.ReadLine());
            foreach (var user in users)
            {
                if (user.UserId == tmpUserId && user.Password == tmpPassword)
                {
                    _user = user;
                    Console.WriteLine("You are now logging in.");
                    LogInOkay = true;
                    return user;
                }
            }
            return null;
        }

        private void ListThreads(SqliteThreadRepository repo)
        {
            var threads = repo.GetThreads();
            Console.WriteLine("\nAll existing threads in the Gaming Forum\n[      Thread Title       |              Thread text              |   OP  | Number of posts]\n");
            foreach (var t in threads)
            {
                if (t.PostCount == 0)
                {
                    Console.WriteLine($"{t.ThreadName} | {t.ThreadText} | {t.Owner} | {t.PostCount}");
                }
                else
                {
                    Console.WriteLine($"{t.ThreadName} | {t.ThreadText} | {t.Owner} | {t.PostCount}");
                }

            }
            Console.ReadKey();
        }

        private void ListPostInThread(SqlitePostRepository pRepo, SqliteThreadRepository tRepo)
        {
            Console.WriteLine("Please enter thread-id where the post has been posted in: ");
            var threadId = int.Parse(Console.ReadLine());
            var thread = tRepo.GetThreadById(threadId);
            var posts = pRepo.GetPostsFromThread(thread);
            Console.WriteLine($"\n\"{thread.ThreadName}  \n {thread.ThreadText}\"\n[   User  |          Comment          ]");
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.User.NickName} | {post.PostComment}");
            }
            ReturnToMenu();
        }

        private void AddThread()
        {
            var thread = new Thread();
            thread.UserId = _user.UserId;
            Console.WriteLine("Please enter the thread title: ");
            thread.ThreadName = Console.ReadLine();
            thread.ThreadName = Validate.OnlyNumberLetters(thread.ThreadName);
            Console.WriteLine("Please enter the text: ");
            thread.ThreadText = Console.ReadLine();
            thread.ThreadText = Validate.OnlyNumberLetters(thread.ThreadText);

            _tr.AddThread(thread);
            ReturnToMenu(); 
        }

        private void AddPostInThread()
        {
            var post = new Post();
            post.UserId = _user.UserId;
            Console.WriteLine("Please enter the thread-ID you want to comment on: ");
            post.ThreadId = int.Parse(Validate.OnlyNumbers(Console.ReadLine()));
            Console.WriteLine("Please enter the post comment: ");
            post.PostComment = Console.ReadLine();
            post.PostComment = Validate.OnlyNumberLetters(post.PostComment);
       
           _pr.AddPost(post);
            ReturnToMenu();
        }

        private void EditPost(SqlitePostRepository repo)
        {
            Console.Write("Please enter the post-ID you want to edit: ");
            var postId = int.Parse(Validate.OnlyNumbers(Console.ReadLine()));
            var post = repo.GetPostById(postId);
            Console.Write("Please enter the change you would like to make in your post: ");
            post.PostComment = Console.ReadLine();
            post.PostComment = Validate.OnlyNumberLetters(post.PostComment);
            if (_user.UserId == post.UserId)
            {
                repo.UpdatePost(post);
            }
            ReturnToMenu();
        }

        private void DeletePost(SqlitePostRepository repo)
        {
            Console.Write("Please enter the post-ID you want to remove: ");
            var postId = int.Parse(Validate.OnlyNumbers(Console.ReadLine()));
            var post = repo.GetPostById(postId);
            if (_user.UserId == post.UserId)
            {
                repo.DeletePost(post);
            }
            ReturnToMenu();
        }

        private void ReturnToMenu()
        {
            Console.WriteLine("Press 'Enter' to return to Main Menue");
            while (Console.ReadKey(false).Key == ConsoleKey.Enter)
            {
                ForumMenu();
            }
        }
    }
}
