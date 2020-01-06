using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORM.entity.Models;
using ORM.entity.ViewModels;

namespace ORM.web.Controllers.BaseController
{
    public interface IBaseController<T> where T: BaseModel
    {
        [HttpGet]
        ActionResult GetAll();
        [HttpGet]
        ActionResult GetByName(string name);
        [HttpGet]
        ActionResult Get(long id);
        [HttpPost]
        ActionResult Post(UserViewModel entity);
    }
}
