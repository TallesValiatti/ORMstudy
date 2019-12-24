
using ORM.entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.services.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAll();
        UserModel Get(long id);
        void Insert(UserModel user);
        void Update(UserModel user);
        void Delete(long id);
    }
}
