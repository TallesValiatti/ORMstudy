using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.entity.Permissions
{
    public static class Permissions
    {
        #region Permissions
        //theses int values may be storeged on some db to allow users to use some funcionallity
        public const string canGetAllUsers = "1";
        public const string canGetSingleUser = "2";
        #endregion

        #region enums of Permissions

        public enum EnumPermissions
        {
            canGetAllUsers = 1,
            canGetSingleUser = 2,
        }

        #endregion
    }
}
