using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace WADAssignmentS2.Pages
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {/*
                User user = new User(Username, Email, ConfirmPassword);
                userController = new UserController();
                userController.AddUser(user);*/
                //return RedirectToPage($"/LoginForm", "User", new { user });
                MySqlConnection connection = new MySqlConnection("Server=studmysql01.fhict.local;Username=dbi450046;Database=dbi450046;Password=Mrf3MwW8di; ssl mode= none");

                try
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `user` (`ID`, `Name`, `Username`, `Email`, `Password`, `AnimeListID`) VALUES (NULL, NULL, @Username, @Email, @Password, NULL)", connection);
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return Page();
                }
                finally
                {
                    connection.Close();
                }
                return RedirectToPage("/LoginForm");
            }
            
        }
    }
}
