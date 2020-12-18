using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ForumApplication
{
    class Validate
    {
        //only letters/numbers/ white space/special characters
        public static string OnlyNumberLetters(string userInput)
        {
            string result = userInput;
            while (!Regex.IsMatch(result, @"[a-zA-Z0-9]*$"))
            {
                Console.WriteLine("Only letter and numbers are valid inputs. \n Special symbols is not a valid character");
                result = Console.ReadLine();
            }
            return result;
        }

        public static string OnlyNumbers(string userInput)
        {
            string result = userInput;
            while (!Regex.IsMatch(result, @"[0-9]"))
            {
                Console.WriteLine("Only numbers ranging in the menu are valid inputs");
                result = Console.ReadLine();
            }
            return result;
        }

        public static string OnlyLetters(string userInput)
        {
            string result = userInput;
            while (!Regex.IsMatch(result, @"^[\p{L}]+$"))
            {
                Console.WriteLine("Only numbers ranging in the menu are valid inputs");
                result = Console.ReadLine();
            }
            return result;
        }

    }
}
