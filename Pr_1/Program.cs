using System;
using UserManagement.BusinessLogicLayer;
using UserManagement.DataAccessLayer;

namespace UserManagement.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);

            while (true)
            {
                Console.WriteLine("\n1. Add User");
                Console.WriteLine("2. Remove User");
                Console.WriteLine("3. List Users");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        var email = Console.ReadLine();
                        userService.AddUser(name, email);
                        break;

                    case "2":
                        Console.Write("Enter Email of user to remove: ");
                        email = Console.ReadLine();
                        userService.RemoveUser(email);
                        break;

                    case "3":
                        userService.ListUsers();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}