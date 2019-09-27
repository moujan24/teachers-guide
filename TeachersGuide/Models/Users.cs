using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class Users
    {
        public int Id { get; set; }
        [DataType(DataType.Password)]
        public string Username { get; set; }
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
