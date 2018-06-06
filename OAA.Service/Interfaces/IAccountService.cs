using System;
using OAA.Data.Models;

namespace OAA.Service.Interfaces
{
    public interface IAccountService
    {
        User GetUser(string login);
        User GetUserBuLoginAndPaswword(string login, string password);
        void Add(User user);
    }
}
