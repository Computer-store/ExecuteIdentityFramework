﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using ExecuteIdentityFramework.Infrastructure;

namespace ExecuteIdentityFramework.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }
        private AppUserManager UserManager
        {
            get
            {


                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                
              
            }
        }
    }
}