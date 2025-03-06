

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BCrypt.Net;

namespace Library
{
    public class Login
    {
        public bool SignIn()
        {
            Console.Write("Enter UserName: ");
            string userName=Console.ReadLine();

            Console.Write("Enter Password: ");
            string password=Console.ReadLine();

            User userObject=new User();
            List<User> users=userObject.ReadUsersFromJson();

            User foundUser=users.Find(u => u.UserName==userName);

            if (foundUser!=null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, foundUser.HashPassword))
                {
                    Console.WriteLine($"Welcome {foundUser.FirstName}!");
                    return true;
                }
            }
            
            Console.WriteLine($"Error. UserName or Password incorrect!");
            return false;
            
        }
    }
}




