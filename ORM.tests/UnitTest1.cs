using System;
using Xunit;
using ORM.services.Services;
using System.Linq;

namespace ORM.tests
{
    //https://forums.asp.net/t/2142507.aspx?Dependency+injection+in+Xunit+project

    public class UnitTest1
    {
        private readonly IUserService _userServices;

        public UnitTest1(IUserService _userServices)
        {
            this._userServices = _userServices;
        }

        [Fact]
        public void can_get_all_users()
        {
            var lstUsers = _userServices.GetAll();
            
            Assert.NotEmpty(lstUsers);
        }
    }
}
