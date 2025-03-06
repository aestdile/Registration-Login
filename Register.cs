
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BCrypt.Net;

namespace Library
{
    public class User
    {
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string UserName{get; set;}
        public string HashPassword{get; set;}
        public string Email{get; set;}
        public string PhoneNumber{get; set;}

        private const string FilePath="users.json";
        public void Register()
        {
            Console.Write("Enter FirstName: ");
            string firstName=Console.ReadLine();

            Console.Write("Enter LastName: ");
            string lastName=Console.ReadLine();

            Console.Write("Enter UserName: ");
            string userName=Console.ReadLine();

            Console.Write("Enter Password: ");
            string password=Console.ReadLine();

            Console.Write("Enter Email: ");
            string email=Console.ReadLine();

            Console.Write("Enter PhoneNumber: ");
            string phoneNumber=Console.ReadLine();

            string hashPassword=BCrypt.Net.BCrypt.HashPassword(password);

            User newUser=new User
            {
                FirstName=firstName,
                LastName=lastName,
                UserName=userName,
                HashPassword=hashPassword,
                Email=email,
                PhoneNumber=phoneNumber
            };

            List<User> users=ReadUsersFromJson();

            users.Add(newUser);

            SaveUsersToJson(users);

            Console.WriteLine("Succesfully entered informations of user!");
        }

        public List<User> ReadUsersFromJson()
        {
            if (!File.Exists(FilePath))
            {
                return new List<User>();
            }

            string json=File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<User>>(json);
        }

        private static void SaveUsersToJson(List<User> users)
        {
            string json=JsonSerializer.Serialize(users, new JsonSerializerOptions{WriteIndented=true});

            File.WriteAllText(FilePath, json);
        }
    }
}

















