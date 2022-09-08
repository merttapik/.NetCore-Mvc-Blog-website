using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMvc.Models
{
    public class UserSignUpViewModel
    {
        [Required(ErrorMessage ="Please enter something")]
        [Display(Name="NameSurname")]
        public string NameSurname { get; set; }
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Not match")]
        public string ConfirmPassword { get; set; }
        public string Mail { get; set; }
        public string UserName { get; set; }
    }
}
