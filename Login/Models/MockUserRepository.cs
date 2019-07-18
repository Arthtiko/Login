using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> userList;

        public MockUserRepository()
        {
            userList = new List<User>()
            {
                new User() { Id = 1, Name = "Taha", Email = "arthtiko@gmail.com", UserName = "arthtiko", Password = "12345", IsAdmin = true },
                new User() { Id = 2, Name = "Raha", Email = "arthtiko@gmail.com", UserName = "user1", Password = "12345", IsAdmin = false },
                new User() { Id = 3, Name = "Maha", Email = "arthtiko@gmail.com", UserName = "user2", Password = "12345", IsAdmin = false },
                new User() { Id = 4, Name = "Baha", Email = "arthtiko@gmail.com", UserName = "user3", Password = "12345", IsAdmin = false }
            };
        }

        public User Add(User user)
        {
            user.Id = userList.Max(e => e.Id) + 1;
            userList.Add(user);
            return user;
        }

        public bool ChangePassword(int Id, string prevPassword, string newPassword)
        {
            User user = userList.FirstOrDefault(e => e.Id == Id);
            if (user != null && prevPassword == user.Password)
            {
                user.Password = newPassword;
                return true;
            }
            return false;
        }

        public User Delete(int Id)
        {
            User user = userList.FirstOrDefault(e => e.Id == Id);
            if (user != null)
            {
                userList.Remove(user);
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userList;
        }

        public User GetUserByUserName(string userName, string password)
        {
            User user = userList.Find(e => e.UserName == userName);
            return user;
        }

        public User GetUser(int Id)
        {
            User user = userList.Find(e => e.Id == Id);
            return user;
        }

        public bool IsAdmin(User user)
        {
            User _user = userList.Find(e => e.UserName == user.UserName);
            return _user.IsAdmin;
        }

        public User Update(User updatedUser)
        {
            User user = userList.FirstOrDefault(e => e.Id == updatedUser.Id);
            if (user != null){
                userList.FirstOrDefault(e => e.Id == updatedUser.Id).Name = updatedUser.Name;
                userList.FirstOrDefault(e => e.Id == updatedUser.Id).Email = updatedUser.Email;
            }
            return user;
        }

        public int GetUserCount()
        {
            throw new NotImplementedException();
        }
    }
}
