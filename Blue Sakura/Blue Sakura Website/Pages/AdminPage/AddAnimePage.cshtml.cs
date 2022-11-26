using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blue_Sakura_Logic.DAL;
using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.EnumCollection;
using Blue_Sakura_Logic.UserCollection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blue_Sakura_Website.Pages.AdminPage
{
    [Authorize(Policy ="AdminOnly")]
    public class AddAnimePageModel : PageModel
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public User user { get; set; }

        public Entertainment Entertainment { get; set; }

        [BindProperty]
        public IFormFile Picture { get; set; }

        public string PicturePath { get; set; }

        [BindProperty]
        [Required]
        public string Title { get; set; }

        [BindProperty]
        public string AlternateTitle { get; set; }

        [BindProperty]
        public string Genre { get; set; }

        [BindProperty]
        [Required]
        public GenreType MainGenre { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Date)]
        public string StartDate { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public string EndDate { get; set; }

        [BindProperty]
        public EntertainmentStatusType Status { get; set; }

        [BindProperty]
        public string Synopsis { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        [Required]
        public string Studio { get; set; }

        [BindProperty]
        public int NrOfEpisode { get; set; }

        [BindProperty]
        public int Duration { get; set; }

        [BindProperty]
        public int? Prequel { get; set; }

        [BindProperty]
        public int? Sequel { get; set; }



        public AddAnimePageModel(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            SetupSelectList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Picture != null)
                {
                    PicturePath = ProcessUploadFile();
                }

                DateTime? endDate = null;
                if(EndDate != null)
                {
                    endDate = DateTime.Parse(EndDate);
                }

                Entertainment = new Anime(Title, MainGenre, DateTime.Parse(StartDate), Studio, Status, AlternateTitle, endDate, Synopsis, Description, PicturePath, Genre, NrOfEpisode, Duration, Prequel, Sequel);

                if(EntertainmentDAL.AddEntertainment(Entertainment))
                {
                    return Redirect("/AdminPage/AdminViewPage");
                }
                OnGet();
                return Page();
            }
            OnGet();
            return Page();
        }

        private string ProcessUploadFile()
        {
            string uniqueFileName = null;

            if (Picture != null)
            {
                string uploadFolder =
                    Path.Combine(webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Picture.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Picture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        public List<SelectListItem> AnimeSelectList { get; set; }

        private void SetupSelectList()
        {
            AnimeSelectList = new List<SelectListItem>();
            List<Entertainment> allEntertainments = EntertainmentDAL.GetAllEntertainment();
            foreach(Entertainment e in allEntertainments)
            {
                AnimeSelectList.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Title});
            }
        }
    }
}
