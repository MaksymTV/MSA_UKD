using System;
using System.Collections.Generic;
using UserManagement.DataAccessLayer;
using UserManagement.Models;

namespace UserManagement.BusinessLogicLayer
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Name and email cannot be empty.");
                return;
            }

            if (_userRepository.EmailExists(email))
            {
                Console.WriteLine("A user with this email already exists.");
                return;
            }

            var newUser = new User(name, email);
            _userRepository.AddUser(newUser);
            Console.WriteLine("User added successfully.");
        }

        public void RemoveUser(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty.");
                return;
            }

            _userRepository.RemoveUser(email);
            Console.WriteLine("User removed successfully.");
        }

        public void ListUsers()
        {
            var users = _userRepository.GetUsers();
            if (users.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }

            Console.WriteLine("Users List:");
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Name}, Email: {user.Email}");
            }
        }
    }
}