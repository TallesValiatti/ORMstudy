using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ORM.services;
using ORM.repo;
using ORM.services.Services;
using ORM.repo.Repository;
using ORM.entity.Models;
using System.Linq;

namespace ORM.tests.UnitTests.User
{   
    public class UserServicesTests
    {
        #region Init
        public Mock<IRepository<UserModel>> mockUserRepo { get; set; }
        public UserServicesTests()
        {
            mockUserRepo = new Mock<IRepository<UserModel>>();
        }
        #endregion

        [Fact(DisplayName ="can_retrieve_all_users")]
        public void can_retrieve_all_users()
        {  
            mockUserRepo.Setup( m => m.GetAll()).Returns(new List<UserModel>() { 
            
                new UserModel()
                {
                    name= "talles",
                    id = 1,
                    password = "123",
                    email = "123@123.com"
                }, 
                new UserModel()
                {
                    name= "talles",
                    id = 2,
                    password = "123",
                    email = "123@123.com"
                }
            });
            var userService = new UserServices(mockUserRepo.Object);

            Assert.NotEmpty(userService.GetAll());
        }

        [Fact(DisplayName = "can_retrieve_one_users")]
        public void can_retrieve_one_users()
        {
            int id = 1;

            mockUserRepo.Setup(m => m.Get(id)).Returns(
                new UserModel()
                {
                    name = "talles",
                    id = 1,
                    password = "123",
                    email = "123@123.com"
                });

            var userService = new UserServices(mockUserRepo.Object);

            Assert.NotNull(userService.Get(id));
        }

        [Fact(DisplayName = "can_insert_user")]
        public void can_insert_user()
        {
            var user = new UserModel()
            {
                name = "talles",
                id = 1,
                password = "123",
                email = "123@123.com"
            };

            mockUserRepo.Setup(m => m.Insert(user));

            var userService = new UserServices(mockUserRepo.Object);
            userService.Insert(user);
        }
    }
}
