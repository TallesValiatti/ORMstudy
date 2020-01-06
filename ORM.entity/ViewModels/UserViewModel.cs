using ORM.entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using ORM.entity.ViewModelsValidation;

namespace ORM.entity.ViewModels
{
    public class UserViewModel
    {
        #region props
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string nameUpCase { get; set; }
        public string nameLowCase { get; set; }
        #endregion

        #region methods

       

        #endregion
    }
}
