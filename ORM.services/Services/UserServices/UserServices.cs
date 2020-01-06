using System;
using System.Collections.Generic;
using ORM.repo.Repository;

using System.Text;
using ORM.entity.Models;
using System.Linq.Expressions;
using System.Linq;

namespace ORM.services.Services
{
    public class UserServices : IUserService
    {
        #region Repository
        private IRepository<UserModel> _userRepository;


        #endregion

        #region Methods

        public UserServices(IRepository<UserModel> userRepository)
        {
            this._userRepository = userRepository;
            //this.userProfileRepository = userProfileRepository;
        }

        public void Delete(long id)
        {
            UserModel user = Get(id);
            _userRepository.Remove(user);
            _userRepository.SaveChanges();
        }

        public UserModel Get(long id)
        {
            return _userRepository.Get(id);
        }

        public IQueryable<UserModel> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IQueryable<UserModel> GetCustom(Expression<Func<UserModel, bool>> predicate)
        {
            return _userRepository.GetCustom(predicate);
        }

        public void Insert(UserModel user)
        {
            _userRepository.Insert(user);
        }

        public void Update(UserModel user)
        {
            _userRepository.Update(user);
        }
        #endregion

    }
}