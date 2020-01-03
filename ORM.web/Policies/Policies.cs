using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ORM.entity.Permissions;


namespace ORM.web.Policies
{
    public static class Policies
    {
        public static AuthorizationPolicy canGetAllUsers()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Permissions.canGetAllUsers).Build();
        }

        public static AuthorizationPolicy canGetSingleUser()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Permissions.canGetSingleUser).Build();
        }
    }
}
