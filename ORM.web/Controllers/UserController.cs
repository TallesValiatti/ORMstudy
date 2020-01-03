    using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ORM.entity.Models;
using ORM.entity.Permissions;
using ORM.services.Services;
using ORM.web.Controllers.BaseController;
using ORM.web.Policies;

namespace ORM.web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase, IBaseController<UserModel>
    {
       
        #region Services
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _log;
        #endregion

        public UserController(IUserService userService, ILogger<UserController> log)
        {
            this._userService = userService;
            this._log = log;
    }

        [HttpGet]
        [Authorize]
        [Authorize(Policy = Permissions.canGetAllUsers)]
        public ActionResult GetAll()
        {
            try
            {
                //Claims
                var a = User.Identity as ClaimsIdentity;
                var claims = a.Claims;

                var lstUsers = _userService.GetAll();

                _log.LogInformation("Listagem de todos os Usuarios: " + lstUsers.Count() + " itens");

                return Ok(lstUsers);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = ex.Message
                });
            }
        }

        [Route("{id}")]
        [HttpGet]
        [Authorize(Policy = Permissions.canGetSingleUser)]
        public ActionResult Get(long id)
        {
            try
            {
                var obj = _userService.Get(id);

                _log.LogInformation("Listagem do usuarios com id: " + id);

                return Ok(obj);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = ex.Message
                });
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] UserModel entity)
        {
            try
            {
                _userService.Insert(entity);
                _log.LogInformation("Inserindo usuario");
                return Ok();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = ex.Message
                });
            }

        }
    }
}