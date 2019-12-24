using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORM.entity.Models;

namespace ORM.web.Controllers.BaseController
{
    public interface IBaseController<T> where T: BaseModel
    {
        [HttpGet]
        ActionResult GetAll();
        [HttpGet]
        ActionResult Get(long id);
        [HttpPost]
        ActionResult Post([FromBody] T entity);
    }
}
