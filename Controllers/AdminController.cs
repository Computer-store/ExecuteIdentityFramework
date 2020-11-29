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
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "User was not found" });
            }
        }
        public async Task<ActionResult> Edit (string id, string email, string password)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validateemail = await UserManager.UserValidator.ValidateAsync(user);
                if (!validateemail.Succeeded)
                {
                    AddErrorsRormResult(validateemail);
                }
                IdentityResult result = 
            }
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