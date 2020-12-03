using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using ExecuteIdentityFramework.Models;

namespace ExecuteIdentityFramework.Infrastructure
{
    public class AppRoleManager:RoleManager<AppRole>, IDisposable
    {
        public AppRoleManager(RoleStore<AppRole> store):base(store)
        {

        }
        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            return new AppRoleManager(new RoleStore<AppRole>(context.Get<ApplIdentityDbContext>()));
        }
    }
}