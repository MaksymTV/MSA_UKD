using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UserManagement.Models;

namespace UserManagement.DataAccessLayer
{
    public class UserRepository
    {
        private string filePath = "Data/users.json";

        public List<User> GetUsers()
        {
            if (!File.Exists(filePath))
                return new List<User>();

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        public void SaveUsers(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void AddUser(User user)
        {
            var users = GetUsers();
            users.Add(user);
            SaveUsers(users);
        }

        public void RemoveUser(string email)
        {
            var users = GetUsers();
            var userToRemove = users.Find(u => u.Email == email);
            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                SaveUsers(users);
            }
        }

        public bool EmailExists(string email)
        {
            var users = GetUsers();
            return users.Exists(u => u.Email == email);
        }
    }
}