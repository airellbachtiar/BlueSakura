using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Blue_Sakura_Logic.UserCollection;
using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.DAL;
using Blue_Sakura_Logic.PersonalEntertainmentCollection;
using Microsoft.AspNetCore.Http;

namespace Blue_Sakura_Website.Pages.PersonalPage
{
    public class PersonalListPageModel : PageModel
    {

        public User user { get; set; } = null;

        public List<PersonalEntertainment> personalEntertainments { get; set; } = new List<PersonalEntertainment>();

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                user = UserDAL.GetUser(Convert.ToInt32(Request.Cookies["UserID"]));
                personalEntertainments = PersonalEntertainmentDAL.GetAllPersonalEntertainments(user.Id);
            }
        }

        public void OnGetRemoveFromList(int entertainmentId)
        {
            //sql remove entertainment
            user = UserDAL.GetUser(Convert.ToInt32(Request.Cookies["UserID"]));
            PersonalEntertainmentDAL.RemovePersonalEntertainment(user, entertainmentId);
            OnGet();
        }
    }
}
