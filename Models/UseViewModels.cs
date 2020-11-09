using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExecuteIdentityFramework.Models
{ 
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    
}