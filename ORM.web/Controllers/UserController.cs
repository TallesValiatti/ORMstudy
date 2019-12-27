using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.entity.Models;
using ORM.services.Services;
using ORM.web.Controllers.BaseController;

namespace ORM.web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase, IBaseController<UserModel>
    {
       
        #region Services
        private readonly IUserService _userService;

        #endregion

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var lstUsers = _userService.GetAll();

                return Ok(lstUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = ex.Message
                });
            }
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult Get(long id)
        {
            try
            {
                var obj = _userService.Get(id);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = ex.Message
                });
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] UserModel entity)
        {
            try
            {
                _userService.Insert(entity);
                return Ok();
            }

            catch (DbUpdateException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = e.Message
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