using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsDatabaseDiscussion.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9_]{7,50}$", ErrorMessage = "Username must be atleast 8 Characters long, must start with a letter and underscores are only allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = ("Password must be atleast 8 characters long"))]
        public string UserPassword { get; set; }

        [Compare("UserPassword", ErrorMessage = "Password does not match")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Name is invalid")]
        public string Name { get; set; }
    }
}