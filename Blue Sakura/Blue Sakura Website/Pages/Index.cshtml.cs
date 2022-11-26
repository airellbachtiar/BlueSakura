using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Blue_Sakura_Logic.UserCollection;
using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.DAL;
using Blue_Sakura_Logic.PersonalEntertainmentCollection;

namespace Blue_Sakura_Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public User user { get; set; } = null;

        [BindProperty]
        public List<Entertainment> entertainments { get; set; } = new List<Entertainment>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            entertainments = EntertainmentDAL.GetAllEntertainment();

            if (User.Identity.IsAuthenticated)
            {
                user = UserDAL.GetUser(Convert.ToInt32(Request.Cookies["UserID"]));
            }
        }

        public void OnGetAddPersonalEntertainment(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                user = UserDAL.GetUser(Convert.ToInt32(Request.Cookies["UserID"]));
                PersonalEntertainment personalEntertainment = new PersonalEntertainment(id);
                PersonalEntertainmentDAL.AddEntertainmentToPersonalEntertainment(user, personalEntertainment);
            }
            OnGet();
        }
    }
}
