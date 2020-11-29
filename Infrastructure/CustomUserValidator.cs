using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using ExecuteIdentityFramework.Models;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExecuteIdentityFramework.Infrastructure
{
    public class CustomUserValidator:UserValidator<AppUser>
    {
        public CustomUserValidator(AppUserManager manager):base(manager)
        {

        }
        public override async Task<IdentityResult> ValidateAsync(AppUser item)
        {
            List<string> errors = new List<string>();
            //default statement
           // IdentityResult result = await base.ValidateAsync(item);
            if (string.IsNullOrEmpty(item.UserName.Trim()))
            {
                errors.Add("you input empty value");
            }
            if (!Regex.IsMatch(item.Email, @" ^ ([a - z0 - 9_ -] +\.) *[a - z0 - 9_ -] +@[a-z0 - 9_ -]+(\.[a-z0 - 9_ -]+)*\.[a-z]{ 2,6}$"))
            {
                errors.Add("you input an uncorrecrt email address");
            }
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }
            return IdentityResult.Success;
        }
    }
}