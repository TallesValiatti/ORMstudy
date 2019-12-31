using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.entity.Models;
using ORM.services.Services;
using ORM.services.Services.TokenService;

namespace ORM.web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        #region Services
        private readonly IUserService _userService;
        private readonly ITokenServices _TokenService;

        #endregion


        public loginController(IUserService userService, ITokenServices TokenService)
        {
            this._userService = userService;
            this._TokenService = TokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult post([FromBody] UserModel _user)
        {
            try
            {
                var lstuser = _userService.GetAll().Where(x => x.name == _user.name && x.password == _user.password);

                if(lstuser.Count() == 0)
                    return StatusCode(StatusCodes.Status404NotFound, new
                    {
                        Error = "user not found"
                    });

                var user = lstuser.FirstOrDefault();

                var token = _TokenService.genereteToken(user);

                // Oculta a senha
                user.password = "******";

                // Retorna os dados
                return Ok(new 
                {
                    token = token
                });
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = ex.Message
                });
            }
        }
    }
}