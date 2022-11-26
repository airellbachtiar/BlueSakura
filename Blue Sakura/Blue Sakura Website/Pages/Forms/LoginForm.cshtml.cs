using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;
using Blue_Sakura_Logic.UserCollection;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Blue_Sakura_Website.Pages
{
    public class LoginFormModel : PageModel
    {
        private User user;

        [BindProperty]
        [Required(ErrorMessage = "Username is missing")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="Password is missing")]
        public string Password { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                user = UserAccess.Login(Username, Password);
                if(user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email)
                    };
                    if(user.IsAdmin)
                    {
                        claims.Add(new Claim("Admin", "True"));
                    }
                    var identity = new ClaimsIdentity(claims, "MyCookiesAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("MyCookiesAuth", claimsPrincipal);

                    Response.Cookies.Append("UserID", user.Id.ToString());
                    if(user.Picture != null)
                    {
                        Response.Cookies.Append("ProfilePicture", user.Picture);
                    }
                    else
                    {
                        Response.Cookies.Append("ProfilePicture", "default.png");
                    }
                    HttpContext.Session.SetInt32("UserID", user.Id);

                    return Redirect("/index");
                }
                return Page();
            }
            return Page();
        }
    }
}
