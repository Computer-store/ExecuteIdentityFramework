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
        public async Task<ActionResult> Create(CreateModel model)
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
                return View("Error", new string[] { "User not found" });
            }
        }
        [HttpPost]
        public async Task <ActionResult> Edit(string id, string email, string pass)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validemail = await UserManager.UserValidator.ValidateAsync(user);
                if (validemail.Succeeded)
                {
                    AddErrorsRormResult(validemail);
                }
                IdentityResult validpass = null;
                if (!string.IsNullOrEmpty(pass))
                {
                    validpass = await UserManager.PasswordValidator.ValidateAsync(pass);
                    if (validpass.Succeeded)
                    {
                        user.PasswordHash = UserManager.PasswordHasher.HashPassword(pass);
                    }
                    else
                    {
                        AddErrorsRormResult(validpass);
                    }
                }
                if ((validemail.Succeeded && validpass==null) || (validemail.Succeeded && pass!=string.Empty && validpass.Succeeded))
                {
                    IdentityResult result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsRormResult(result);
                    }
                }
               
            } 
            else
            {
                ModelState.AddModelError("", "User Not found");
            }
            return View(user);
        }
        public async Task<ActionResult> Edit(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
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