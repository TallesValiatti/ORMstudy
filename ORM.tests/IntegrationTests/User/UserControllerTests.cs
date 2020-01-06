using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ORM.services.Services;
using ORM.entity.Models;
using ORM.web.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ORM.tests.IntegrationTests.User
{
    public class UserControllerTests
    {
        #region init
        Mock<IUserService> mockUserServices;
        public UserControllerTests()
        {
            mockUserServices = new Mock<IUserService>();
        }
        #endregion

        [Fact(DisplayName = "can_get_all_users")]
        public void can_get_all_users()
        {
            mockUserServices.Setup(m => m.GetAll()).Returns(new List<UserModel>() {

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

            // create a log to server to the controller
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<UserController>();

            var controller = new UserController(mockUserServices.Object, logger);
            var response = (ObjectResult)controller.GetAll();
            
            Assert.Equal( StatusCodes.Status200OK, response.StatusCode);
        }

        [Fact(DisplayName = "can_get_one_users")]
        public void can_get_one_users()
        {
            int id = 1;
            mockUserServices.Setup(m => m.Get(id)).Returns((new List<UserModel>() {

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
            }).Find(x => x.id == id));

            // create a log to server to the controller
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<UserController>();

            var controller = new UserController(mockUserServices.Object, logger);
            var response = controller.Get(id) as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
        }
    }
}
