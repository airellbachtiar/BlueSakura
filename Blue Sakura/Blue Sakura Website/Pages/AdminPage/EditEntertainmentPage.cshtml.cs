using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blue_Sakura_Logic.DAL;
using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.EnumCollection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blue_Sakura_Website.Pages.AdminPage
{
    public class EditEntertainmentPageModel : PageModel
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public Entertainment Entertainment { get; set; }

        [BindProperty(SupportsGet = true)]
        public int EntertainmentID { get; set; }

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
        public int SelectedMainGenre { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Date)]
        public string StartDate { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public string EndDate { get; set; }

        [BindProperty]
        public int SelectedStatus { get; set; }

        [BindProperty]
        public string Synopsis { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public List<SelectListItem> AnimeSelectList { get; set; }

        public List<SelectListItem> GenreTypeList { get; set; }

        public List<SelectListItem> StatusTypeList { get; set; }

        //ANIME

        [BindProperty]
        public string Studio { get; set; }

        [BindProperty]
        public int NrOfEpisode { get; set; }

        [BindProperty]
        public int Duration { get; set; }

        [BindProperty]
        public int? Prequel { get; set; }

        [BindProperty]
        public int? Sequel { get; set; }

        //MANGA
        [BindProperty]
        public string Author { get; set; }

        [BindProperty]
        public int Volume { get; set; }

        [BindProperty]
        public int Chapter { get; set; }

        public EditEntertainmentPageModel(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            if(EntertainmentID > 0)
            {
                Entertainment = EntertainmentDAL.GetEntertainment(EntertainmentID);
                StartDate = Entertainment.StartDate.ToString("yyyy-MM-dd");
                SelectedMainGenre = (int)Entertainment.MainGenre;
                SelectedStatus = (int)Entertainment.Status;
                if(Entertainment.EndDate != null)
                {
                    DateTime temp = (DateTime)Entertainment.EndDate;
                    EndDate = temp.ToString("yyyy-MM-dd");

                }
                SetupSelectList();
            }
        }

        public IActionResult OnPost()
        {
            Entertainment = EntertainmentDAL.GetEntertainment(EntertainmentID);

            if(ModelState.IsValid)
            {
                Entertainment.MainGenre = (GenreType)SelectedMainGenre;
                Entertainment.Status = (EntertainmentStatusType)SelectedStatus;
                Entertainment.Title = Title;
                Entertainment.AlternateTitle = AlternateTitle;
                Entertainment.StartDate = DateTime.Parse(StartDate);
                if(EndDate != null)
                {
                    Entertainment.EndDate = DateTime.Parse(EndDate);
                }
                Entertainment.Synopsis = Synopsis;
                Entertainment.Description = Description;
                if (Picture != null)
                {
                    if (Entertainment.Picture != null && Entertainment.Picture != "default.png")
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "img", Entertainment.Picture);
                        System.IO.File.Delete(filePath);
                    }
                    PicturePath = ProcessUploadFile();
                    Entertainment.Picture = PicturePath;
                }

                if (Entertainment is Anime)
                {
                    ((Anime)Entertainment).Studio = Studio;
                    ((Anime)Entertainment).NrOfEpisode = NrOfEpisode;
                    ((Anime)Entertainment).Duration = Duration;
                    ((Anime)Entertainment).Prequel = Prequel;
                    ((Anime)Entertainment).Sequel = Sequel;
                }
                else if(Entertainment is Manga)
                {
                    ((Manga)Entertainment).Author = Author;
                    ((Manga)Entertainment).Volumes = Volume;
                    ((Manga)Entertainment).Chapters = Chapter;
                }

                EntertainmentDAL.UpdateEntertainment(Entertainment);

                return Redirect("/AdminPage/AdminViewPage");
            }
            OnGet();
            return Page();
        }

        private void SetupSelectList()
        {
            AnimeSelectList = new List<SelectListItem>();
            GenreTypeList = new List<SelectListItem>();
            StatusTypeList = new List<SelectListItem>();
            List<Entertainment> allEntertainments = EntertainmentDAL.GetAllEntertainment();
            foreach (Entertainment e in allEntertainments)
            {
                AnimeSelectList.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Title });
            }

            foreach (GenreType g in Enum.GetValues(typeof(GenreType)).Cast<GenreType>().ToList())
            {
                GenreTypeList.Add(new SelectListItem { Value = ((int)g).ToString(), Text = g.ToString() });
            }

            foreach (EntertainmentStatusType s in Enum.GetValues(typeof(EntertainmentStatusType)).Cast<EntertainmentStatusType>().ToList())
            {
                StatusTypeList.Add(new SelectListItem { Value = ((int)s).ToString(), Text = s.ToString() });
            }
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
    }
}
