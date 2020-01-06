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
using AutoMapper;
using ORM.entity.AutoMapping;
using ORM.entity.ViewModels;
using System.Collections;
using System.Linq.Expressions;

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
                var lstUsers = _userService.GetAll();
                var lstUserViewModel = UserAutoMapping.MappingListModelToListViewModel(lstUsers);

               _log.LogInformation("Listagem de todos os Usuarios: " + lstUserViewModel.Count() + " itens");

                //return a list of view models
                return new OkObjectResult(lstUserViewModel);
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
                var ObjViewModel = UserAutoMapping.MappingModelToViewModel(obj);

                _log.LogInformation("Listagem do usuarios com id: " + id);



                //return a view model
                return Ok(ObjViewModel);
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
        public ActionResult Post([FromBody] UserViewModel entity)
        {
            try
            {
                var a = ModelState.IsValid;

                var ObjModel = UserAutoMapping.MappingViewModelToModel(entity);
                _userService.Insert(ObjModel);
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

        [Route("name/{name}")]
        [HttpGet]
        [Authorize(Policy = Permissions.canGetSingleUser)]
        public ActionResult GetByName(string name)
        {
            try
            {
                Expression<Func<UserModel, bool>> getCustom = x => x.name.Contains(name);

          
                var lstUsers = _userService.GetCustom(getCustom);
                var lstUserViewModel = UserAutoMapping.MappingListModelToListViewModel(lstUsers);

                _log.LogInformation("Listagem de todos os Usuarios com nome "+ name + ": " + lstUserViewModel.Count() + " itens");

                //return a list of view models
                return new OkObjectResult(lstUserViewModel);
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