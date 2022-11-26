using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blue_Sakura_Website.Pages.AdminPage
{
    [Authorize(Policy = "AdminOnly")]
    public class AddEntertainmentOptionPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
