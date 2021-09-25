using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Dtos
{
    public class RegisterViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string Lname { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }




        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        //joe@aol.com | a@b.c
        [RegularExpression(@"[\w-]+@([\w-]+\.)+[\w-]+")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
