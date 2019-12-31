using ORM.entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.services.Services.TokenService
{
    public interface ITokenServices
    {
        string genereteToken(UserModel user);
    }
}
