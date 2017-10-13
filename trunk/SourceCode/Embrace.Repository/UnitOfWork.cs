using Embrace.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Embrace.Repository
{
    public interface IUnitOfWork
    {
        void Save();
        Repository<Contacts> ContactRepository { get; }
    }
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context; 
        }
        private Repository<Contacts> contactRepository;
        public Repository<Contacts> ContactRepository
        {
            get
            {

                if (this.contactRepository == null)
                {
                    this.contactRepository = new Repository<Contacts>(context);
                }
                return contactRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }        
    }
}
