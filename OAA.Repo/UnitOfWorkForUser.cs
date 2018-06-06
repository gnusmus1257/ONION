using OAA.Data;
using OAA.Data.Models;
using OAA.Repo.Intarfaces;
using OAA.Repo.Repositories;
using OAA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAA.Repo
{
    public class UnitOfWorkForUser : IUnitOfWorkForUser
    {
        private ApplicationContext db;

        private RepoForUser<User> userRepository;

        public UnitOfWorkForUser(ApplicationContext context)
        {
            db = context;
        }

        public IRepoForUser<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new RepoForUser<User>(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
