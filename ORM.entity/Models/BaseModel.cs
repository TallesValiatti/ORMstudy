using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORM.entity.Models
{
    public class BaseModel
    {
        [Key]
        public int id { get; set; }
    }
}
