using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public bool ChangePassword(int Id, string prevPassword, string newPassword)
        {
            return false;
        }

        public User Delete(int Id)
        {
            User user = context.Users.Find(Id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public User GetUser(int Id)
        {
            return context.Users.Find(Id);
        }

        public User GetUserByUserName(string userName, string password)
        {
            User user = context.Users.Where(s => s.UserName == userName).FirstOrDefault();
            //User user = context.Users.Find(userName);
            return user;
        }

        public int GetUserCount()
        {
            return context.Users.Count();
        }

        public bool IsAdmin(User user)
        {
            throw new NotImplementedException();
        }

        public User Update(User changedUser)
        {
            var employee = context.Users.Attach(changedUser);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return changedUser;
        }
    }
}
