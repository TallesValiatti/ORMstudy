using Microsoft.EntityFrameworkCore;
using ORM.entity.Models;
using ORM.repo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM.repo.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        void IRepository<T>.Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        T IRepository<T>.Get(long id)
        {
            return entities.SingleOrDefault(s => s.id == id);
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return entities.AsEnumerable();
        }

        void IRepository<T>.Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        void IRepository<T>.Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        void IRepository<T>.SaveChanges()
        {
            context.SaveChanges();
        }

        void IRepository<T>.Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
