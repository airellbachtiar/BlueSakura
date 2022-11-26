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
using Blue_Sakura_Logic.EnumCollection;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blue_Sakura_Website.Pages.PersonalPage
{
    public class PersonalIndividualPageModel : PageModel
    {
        public User user { get; set; }

        [BindProperty(SupportsGet = true)]
        public int EntertainmentID { get; set; }

        public Entertainment Entertainment { get; set; }
        
        public PersonalStatusType statusOption { get; set; }

        [BindProperty]
        public int SelectedStatus { get; set; }

        public List<SelectListItem> StatusList { get; set; }

        [BindProperty]
        public int Progress { get; set; }

        public PersonalEntertainment PersonalEntertainment { get; set; }

        public void OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                user = UserDAL.GetUser(Convert.ToInt32(Request.Cookies["UserID"]));
            }
            if(EntertainmentID > 0)
            {
                //get chosen personal entertainment
                PersonalEntertainment = PersonalEntertainmentDAL.GetPersonalEntertainment(user.Id, EntertainmentID);
                Entertainment = EntertainmentDAL.GetEntertainment(PersonalEntertainment.EntertainmentID);
                Response.Cookies.Append("EntertainmentID", EntertainmentID.ToString());
                StatusList = StatusTypes(Entertainment);
                SelectedStatus = (int)PersonalEntertainment.Status;
            }
            else if(Request.Cookies["EntertainmentID"] != null)
            {
                EntertainmentID = Convert.ToInt32(Request.Cookies["EntertainmentID"]);
                PersonalEntertainment = PersonalEntertainmentDAL.GetPersonalEntertainment(user.Id, EntertainmentID);
                Entertainment = EntertainmentDAL.GetEntertainment(PersonalEntertainment.EntertainmentID);
                StatusList = StatusTypes(Entertainment);
            }
        }

        public IActionResult OnPost()
        {
            EntertainmentID = Convert.ToInt32(Request.Cookies["EntertainmentID"]);
            user = UserDAL.GetUser(Convert.ToInt32(Request.Cookies["UserID"]));
            PersonalEntertainment = PersonalEntertainmentDAL.GetPersonalEntertainment(user.Id, EntertainmentID);
            Entertainment = EntertainmentDAL.GetEntertainment(PersonalEntertainment.EntertainmentID);

            if (ModelState.IsValid)
            {
                PersonalEntertainment.Status = (PersonalStatusType)SelectedStatus;
                if (Entertainment is Blue_Sakura_Logic.EntertainmentCollection.Anime)
                {
                    if(Progress <= ((Blue_Sakura_Logic.EntertainmentCollection.Anime)Entertainment).NrOfEpisode)
                        PersonalEntertainment.Progress = Progress;
                    if (PersonalEntertainment.Status == PersonalStatusType.COMPLETED)
                        PersonalEntertainment.Progress = ((Blue_Sakura_Logic.EntertainmentCollection.Anime)Entertainment).NrOfEpisode;
                }
                
                else if(Entertainment is Blue_Sakura_Logic.EntertainmentCollection.Manga)
                {
                    if(Progress <= ((Blue_Sakura_Logic.EntertainmentCollection.Manga)Entertainment).Chapters)
                        PersonalEntertainment.Progress = Progress;
                    if (PersonalEntertainment.Status == PersonalStatusType.COMPLETED)
                        PersonalEntertainment.Progress = (int)((Blue_Sakura_Logic.EntertainmentCollection.Manga)Entertainment).Chapters;
                }

                PersonalEntertainmentDAL.UpdatePersonalEntertainment(user, PersonalEntertainment);
                return Redirect("/PersonalPage/PersonalListPage");
            }
            OnGet();
            return Page();
        }

        private static List<SelectListItem> StatusTypes(Entertainment entertainment)
        {
            List<SelectListItem> statuses = new List<SelectListItem>();
            if(entertainment is Blue_Sakura_Logic.EntertainmentCollection.Anime)
            {
                foreach(PersonalStatusType s in Enum.GetValues(typeof(PersonalStatusType)).Cast<PersonalStatusType>().ToList())
                {
                    if(s != PersonalStatusType.READING)
                    {
                        statuses.Add(new SelectListItem { Value = ((int)s).ToString(), Text = s.ToString()});
                    }
                }
            }
            else
            {
                foreach (PersonalStatusType s in Enum.GetValues(typeof(PersonalStatusType)).Cast<PersonalStatusType>().ToList())
                {
                    if (s != PersonalStatusType.WATCHING)
                    {
                        statuses.Add(new SelectListItem { Value = ((int)s).ToString(), Text = s.ToString() });
                    }
                }
            }
            return statuses;
        }
    }
}
