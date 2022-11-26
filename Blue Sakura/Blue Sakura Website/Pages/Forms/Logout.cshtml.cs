using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blue_Sakura_Website.Pages.Forms
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            HttpContext.Session.Remove("UserID");
            Response.Cookies.Delete("UserID");
            Response.Cookies.Delete("ProfilePicture");
            await HttpContext.SignOutAsync("MyCookiesAuth");
            return RedirectToPage("/Index");
        }
    }
}
