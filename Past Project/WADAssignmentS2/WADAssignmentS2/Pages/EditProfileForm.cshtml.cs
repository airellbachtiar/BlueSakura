using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace WADAssignmentS2.Pages
{
    public class EditProfileFormModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Insert email")]
        public string Email { get; set; }

        [BindProperty]
        public string Picture { get; set; }

        [BindProperty]
        //[Compare(nameof(oldPassword), ErrorMessage = "Incorrect Password")]
        public string Password { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        [Compare(nameof(Password), ErrorMessage = "New passwords don't match.")]
        public string ConfirmNewPassword { get; set; }

        [BindProperty]
        public User user { get; set; } = null;


        public void OnGet()
        {
            user = Class.DAL.UserDAL.GetUser(HttpContext.Session.GetInt32("UserID"));
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                if(!string.IsNullOrWhiteSpace(ConfirmNewPassword) && user.Password == ConfirmNewPassword)
                {
                    //Inser SQL with new password
                }
                else
                {
                    //Insert SQL
                    return Redirect("/index");
                }
            }
            return Page();
        }
    }
}
