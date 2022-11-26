using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue_Sakura_Logic.DAL;
using Blue_Sakura_Logic.PersonalEntertainmentCollection;
using Blue_Sakura_Logic.UserCollection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blue_Sakura_Website.Pages.FrontPage
{
    public class ViewUserPageModel : PageModel
    {

        public User user { get; set; } = null;

        [BindProperty(SupportsGet = true)]
        public int UserID { get; set; }

        public List<PersonalEntertainment> personalEntertainments { get; set; } = new List<PersonalEntertainment>();

        public void OnGet()
        {
            user = UserDAL.GetUser(UserID);
            personalEntertainments = PersonalEntertainmentDAL.GetAllPersonalEntertainments(UserID);
        }
    }
}
