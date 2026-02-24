using ObuvnoyWPF.Database;
using ObuvnoyWPF.Services;
using ObuvnoyWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnoyWPF.Controllers
{
    public class UserController
    {
        private DatabaseContext _dbContext = new();
        private MessageManager _message = new();

        public int GetLastUserId()
        {
            return _dbContext.Users.Last().Id;
        }

        public void AddNewUser(string userFullName, string userEmail, string userPassword, int userRoleId)
        {
            var newUser = new User
            {
                FullName = userFullName,
                Email = userEmail,
                Password = userPassword,
                UserRoleId = userRoleId
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            _message.Success("Успешно добавлено.");

        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public void RemoveUserById(int userId)
        {
            var user = GetUserById(userId);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            _message.Success("Успешно удалено.");
        }

        public UserRole GetUserRoleById(int userRoleId)
        {
            return _dbContext.UserRoles.Find(userRoleId);
        }
    }
}
