using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue_Sakura_Logic.DAL;
using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.PersonalEntertainmentCollection;
using Blue_Sakura_Logic.UserCollection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blue_Sakura_Website.Pages.FrontPage
{
    public class ViewUserPersonalIndividualEntertainmentModel : PageModel
    {
        public User user { get; set; }

        [BindProperty(SupportsGet = true)]
        public int EntertainmentID { get; set; }

        public Entertainment Entertainment { get; set; }

        public PersonalEntertainment PersonalEntertainment { get; set; }

        [BindProperty(SupportsGet = true)]
        public int UserID { get; set; }

        public void OnGet()
        {
            if (UserID > 0)
            {
                user = UserDAL.GetUser(UserID);
            }
            if (EntertainmentID > 0)
            {
                //get chosen personal entertainment
                PersonalEntertainment = PersonalEntertainmentDAL.GetPersonalEntertainment(UserID, EntertainmentID);
                Entertainment = EntertainmentDAL.GetEntertainment(PersonalEntertainment.EntertainmentID);
                Response.Cookies.Append("EntertainmentID", EntertainmentID.ToString());
            }
            else if (Request.Cookies["EntertainmentID"] != null)
            {
                EntertainmentID = Convert.ToInt32(Request.Cookies["EntertainmentID"]);
                PersonalEntertainment = PersonalEntertainmentDAL.GetPersonalEntertainment(user.Id, EntertainmentID);
                Entertainment = EntertainmentDAL.GetEntertainment(PersonalEntertainment.EntertainmentID);
            }
        }
    }
}
