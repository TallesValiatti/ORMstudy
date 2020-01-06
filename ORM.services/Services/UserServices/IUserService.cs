
using ORM.entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ORM.services.Services
{
    public interface IUserService
    {
        IQueryable <UserModel> GetAll();
        IQueryable<UserModel> GetCustom(Expression<Func<UserModel, bool>> predicate );
        UserModel Get(long id);
        void Insert(UserModel user);
        void Update(UserModel user);
        void Delete(long id);
    }
}
