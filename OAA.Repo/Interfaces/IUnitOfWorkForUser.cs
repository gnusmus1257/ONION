using OAA.Data;
using OAA.Data.Models;
using OAA.Repo.Intarfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAA.Service.Interfaces
{
    public interface IUnitOfWorkForUser : IDisposable
    {
        IRepoForUser<User> Users { get; }
        void Save();
    }
}
