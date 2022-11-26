using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;
using Blue_Sakura_Logic.UserCollection;
using Blue_Sakura_Logic.DAL;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Blue_Sakura_Website.Pages
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
        public string NewPassword { get; set; }

        [BindProperty]
        [Compare(nameof(NewPassword), ErrorMessage = "New passwords don't match.")]
        public string ConfirmNewPassword { get; set; }

        public User user { get; set; }

        [BindProperty]
        public IFormFile Picture { get; set; }

        public string PicturePath { get; set; }

        private readonly IWebHostEnvironment webHostEnvironment;

        public EditProfileFormModel(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                user = UserDAL.GetUser(Convert.ToInt32(Request.Cookies["UserID"]));
            }
        }

        public IActionResult OnPost()
        {
            user = UserDAL.GetUser(Convert.ToInt32(Request.Cookies["UserID"]));
            if (!ModelState.IsValid)
            {
                OnGet();
                return Page();
            }
            else
            {
                user.Name = Name;
                user.Email = Email;
                user.Username = Username;

                if (Picture != null)
                {
                    if (user.Picture != null || user.Picture != "default.jpg")
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "pfp", user.Picture);
                        System.IO.File.Delete(filePath);
                    }
                    PicturePath = ProcessUploadFile();
                    user.Picture = PicturePath;
                }

                if (!string.IsNullOrWhiteSpace(ConfirmNewPassword))
                {
                    user.Password = HashSaltGenerator.GetHash(ConfirmNewPassword, user.Salt);
                    UserDAL.UpdateUserWithPassword(user);
                    //Inser SQL with new password
                    return Redirect("/index");
                }
                else
                {
                    //Insert SQL
                    UserDAL.UpdateUser(user);
                    return Redirect("/index");
                }
            }
        }

        private string ProcessUploadFile()
        {
            string uniqueFileName = null;

            if (Picture != null)
            {
                string uploadFolder =
                    Path.Combine(webHostEnvironment.WebRootPath, "pfp");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Picture.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Picture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
