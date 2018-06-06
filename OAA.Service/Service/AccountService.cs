using System;
using OAA.Service.Interfaces;
using System.Linq;
using OAA.Data.Models;

namespace OAA.Service.Service
{
    public class AccountService : IAccountService
    {
        IUnitOfWorkForUser Database { get; set; }

        public AccountService(IUnitOfWorkForUser uow)
        {
            Database = uow;
        }

        public User GetUser(string login)
        {
            return Database.Users.GetAll().FirstOrDefault(a => a.Email == login);
        }

        public void Add(User user)
        {
            Database.Users.Create(user);
            Database.Save();
        }

        public User GetUserBuLoginAndPaswword(string login, string password)
        {
            return Database.Users.GetAll().FirstOrDefault(u => u.Email == login && u.PasswordHash == password);
        }
    }


}