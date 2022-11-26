using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Http;

namespace WADAssignmentS2.Pages
{
    public class IndividualPagesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public User user { get; set; } = null;

        [BindProperty(SupportsGet = true)]
        public int AnimeID { get; set; }

        [BindProperty]
        public Class.Anime anime { get; set; } = null;

        public void OnGet()
        {
            if(AnimeID != -1)
            {
                anime = Class.DAL.AnimeDAL.GetAnime(AnimeID);
            }
            if (HttpContext.Session.GetInt32("UserID") != -1 && HttpContext.Session.GetInt32("UserID") != null)
            {
                user = Class.DAL.UserDAL.GetUser(HttpContext.Session.GetInt32("UserID"));
            }
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("UserID");
            RedirectToPage("/index");
        }
    }
}
