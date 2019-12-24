using System;
using System.Collections.Generic;
using System.Text;
using ORM.entity.Models;

namespace ORM.repo.Repository
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
