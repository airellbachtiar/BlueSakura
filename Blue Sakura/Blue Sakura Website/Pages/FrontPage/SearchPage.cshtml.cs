using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue_Sakura_Logic.DAL;
using Blue_Sakura_Logic.UserCollection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blue_Sakura_Website.Pages.FrontPage
{
    public class SearchPageModel : PageModel
    {
        [BindProperty]
        public List<User> Users { get; set; }

        public User user { get; set; } = null;

        [BindProperty(SupportsGet = true)]
        public string SearchInput { get; set; }

        public void OnGet()
        {
            if(SearchInput == null)
            {
                SearchInput = "";
            }
            Users = UserDAL.SearchUser(SearchInput);

            if(User.Identity.IsAuthenticated)
            {
                user = UserDAL.GetUser(Convert.ToInt32(Request.Cookies["UserID"]));
            }
        }
    }
}
