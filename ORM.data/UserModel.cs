using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.data
{  
    [Table("tbluser")]
    class UserModel : BaseEntity
    {
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }

    }
}
