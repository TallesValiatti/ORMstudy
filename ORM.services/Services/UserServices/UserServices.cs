using System;
using System.Collections.Generic;
using ORM.repo.Repository;

using System.Text;
using ORM.entity.Models;

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

        public IEnumerable<UserModel> GetAll()
        {
            return _userRepository.GetAll();
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