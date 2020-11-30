using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using ExecuteIdentityFramework.Infrastructure;
using ExecuteIdentityFramework.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace ExecuteIdentityFramework.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsRormResult(result);
                }
            }
            
            return View(model);
        }
        private void AddErrorsRormResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
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