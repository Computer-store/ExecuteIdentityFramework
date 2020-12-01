using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ExecuteIdentityFramework.Models
{ 
    public class CreateModel
    {
        [Required (ErrorMessage ="Please input name attribute")]
        public string Name { get; set; }
        [Required (ErrorMessage ="please enter correct email address")]
        [RegularExpression(".+\\@.+\\..+" ,ErrorMessage ="you input uncorrect email address, please try ageain")]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        public String Email { get; set; }
        [Required (ErrorMessage ="Please enter password")]
        public string Password { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }

}