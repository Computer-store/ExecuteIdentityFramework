using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ExecuteIdentityFramework.Models;

namespace ExecuteIdentityFramework.Infrastructure
{
    public class ApplIdentityDbContext : IdentityDbContext<AppUser>
        
    {
        
        public ApplIdentityDbContext() : base("IdentityDb") { }
        static ApplIdentityDbContext()
        {
            Database.SetInitializer<ApplIdentityDbContext>(new IdentityDbInit());
        }
        public static ApplIdentityDbContext Create()
        {
            return new ApplIdentityDbContext();
        }
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApplIdentityDbContext>
    {
        protected override void Seed(ApplIdentityDbContext context)
        {
            PerfomInicialSetup(context);
            base.Seed(context);
        }
        public void PerfomInicialSetup(ApplIdentityDbContext context)
        {
            //context configurations settings
        }
    }
}