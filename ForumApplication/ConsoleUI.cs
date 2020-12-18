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
            Console.WriteLine("--WELCOME TO THE GAMING FORUM--");
            Console.WriteLine("Please choose your command by typing a number ranging between 0 - 7");
            Console.WriteLine("1): Create a user account");
            Console.WriteLine("2): List all threads");
            Console.WriteLine("3): List all posts in a specific thread");
            Console.WriteLine("4): Replay with a post in a specific thread");
            Console.WriteLine("5): Create a thread");
            Console.WriteLine("6): Edit a post");
            Console.WriteLine("7): Remove a post");
            Console.WriteLine("0): Exit the app");

            var command = Validate.OnlyNumbers(Console.ReadLine());
            switch (command)
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    ListThreads(_tr);
                    break;
                case "3":
                    ListPostInThread(_pr, _tr);
                    break;
                case "4":
                    AddPostInThread();
                    break;
                case "5":
                    AddThread();
                    break;
                case "6":
                    EditPost(_pr);
                    break;
                case "7":
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

        //funkar ej
        private void AddUser()
        {
            var user = new User();

            Console.WriteLine("Please enter you first name: ");
            user.FirstName = Console.ReadLine();
            user.FirstName = Validate.OnlyLetters(user.FirstName);

            Console.WriteLine("Please enter you last name: ");
            user.LastName = Console.ReadLine();
            user.LastName = Validate.OnlyLetters(user.LastName);

            Console.WriteLine("Please enter you nick name that will be displayed in the Forum: ");
            user.NickName = Console.ReadLine();
            user.NickName = Validate.OnlyLetters(user.NickName);

            Console.WriteLine("Please enter your password: ");
            user.Password = int.Parse(Console.ReadLine());
            _ur.AddUser(user);

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
            Console.WriteLine($"\n\"{thread.ThreadName}  \n {thread.ThreadText}\"\n[   OP  |         Comment        | ]");
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.User.NickName} | {post.PostComment}");
            }
            ReturnToMenu();
        }

        //funkar ej
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
        }

        private void AddPostInThread()
        {
            var post = new Post();
            post.UserId = _user.UserId;
            Console.WriteLine("Please enter the thread-ID you want to comment on: ");
            post.ThreadId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the post comment: ");
            post.PostComment = Console.ReadLine();
            post.PostComment = Validate.OnlyNumberLetters(post.PostComment);
            if (_user.UserId == post.UserId)
            {
                _pr.AddPost(post);
            }
                
        }

        private void EditPost(SqlitePostRepository repo)
        {
            Console.Write("Please enter the post-ID you want to edit: ");
            var postId = int.Parse(Console.ReadLine());
            var post = repo.GetPostById(postId);
            if (_user.UserId == post.UserId) 
            {
                repo.UpdatePost(post);
            }
               
        }

        private void DeletePost(SqlitePostRepository repo)
        {
            Console.Write("Please enter the post-ID you want to remove: ");
            var postId = int.Parse(Console.ReadLine());
            var post = repo.GetPostById(postId);
            if (_user.UserId == post.UserId)
            {
                repo.DeletePost(post);
            }
            
        }

        private void ReturnToMenu()
        {
            Console.WriteLine("Press 'Enter' to return to Main Menue");
            while (Console.ReadKey(false).Key == ConsoleKey.Enter)
            {
                ForumMenu();
            }
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
