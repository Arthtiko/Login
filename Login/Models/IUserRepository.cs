using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public interface IUserRepository
    {
        User GetUserByUserName(string userName, string password);
        int GetUserCount();
        User GetUser(int Id);
        IEnumerable<User> GetAllUsers();
        User Add(User user);
        User Delete(int Id);
        User Update(User user);
        bool ChangePassword(int Id, string prevPassword, string newPassword);
        bool IsAdmin(User user);

    }
}
