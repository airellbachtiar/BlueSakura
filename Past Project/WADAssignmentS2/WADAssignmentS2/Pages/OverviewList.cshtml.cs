using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Http;

namespace WADAssignmentS2.Pages
{
    public class OverviewListModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public User user { get; set; } = null;

        [BindProperty]
        public List<Class.Anime> Animes { get; set; } = new List<Class.Anime>();

        public void OnGet()
        {
            Animes = Class.DAL.AnimeDAL.GetAllAnimes();

            if (HttpContext.Session.GetInt32("UserID") != -1 && HttpContext.Session.GetInt32("UserID") != null)
            {
                user = Class.DAL.UserDAL.GetUser(HttpContext.Session.GetInt32("UserID"));
            }
        }

        public void OnGetLogout()
        {
            Animes = Class.DAL.AnimeDAL.GetAllAnimes();
            HttpContext.Session.Remove("UserID");
            Page();
        }
    }
}
