using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;

namespace WADAssignmentS2.Pages
{
    public class LoginFormModel : PageModel
    {
        public User user { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Username is missing")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="Password is missing")]
        public string Password { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                /*if(UserController.users.Count == 0 && Password == "1" && Username == "a")
                {
                    return RedirectToPage("/Index");
                }
                foreach (User u in UserController.users)
                {
                    if (u.Username == Username && u.Password == Password)
                    {
                        return RedirectToPage("/Index");
                    }
                }*/

                try
                {
                    List<User> users = new List<User>();
                    users = Class.DAL.UserDAL.GetAllUsers();
    
                    foreach (User u in users)
                    {
                        if(u.Username == Username && u.Password == Password)
                        {
                            HttpContext.Session.SetInt32("UserID", u.ID);

                            string url = $"/index";
                            return Redirect(url);
                        }
                    }
                }
                catch (Exception)
                {

                }
                return Page();
            }
            return Page();
        }
    }
}
