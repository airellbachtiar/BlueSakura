using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue_Sakura_Logic.DAL;
using Blue_Sakura_Logic.EntertainmentCollection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blue_Sakura_Website.Pages.AdminPage
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminViewPageModel : PageModel
    {
        [BindProperty]
        public List<Entertainment> Entertainments { get; set; }

        public void OnGet()
        {
            Entertainments = EntertainmentDAL.GetAllEntertainment();
        }

        public void OnGetRemoveFromList(int entertainmentId)
        {
            EntertainmentDAL.RemoveEntertainment(entertainmentId);
            OnGet();
        }
    }
}
