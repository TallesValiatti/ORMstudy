using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORM.entity.Models
{
    [Table("tbluser")]
    public class UserModel : BaseModel
    {
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }

    }
}
