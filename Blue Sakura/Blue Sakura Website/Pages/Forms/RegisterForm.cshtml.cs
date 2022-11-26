using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using MySql.Data;
using MySql.Data.MySqlClient;
using Blue_Sakura_Logic.UserCollection;

namespace Blue_Sakura_Website.Pages
{
    public class RegisterFormModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Insert email")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (UserAccess.RegisterUser(Email, Username, Password))
                {
                    return RedirectToPage("/Forms/LoginForm");
                }
                return Page();
            }
            return Page();
            
        }
    }
}
