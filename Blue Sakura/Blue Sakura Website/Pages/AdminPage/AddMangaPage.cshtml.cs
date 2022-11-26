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

namespace Blue_Sakura_Website.Pages.AdminPage
{
    [Authorize(Policy ="AdminOnly")]
    public class AddMangaPageModel : PageModel
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
        public string Author { get; set; }

        [BindProperty]
        public int Volume { get; set; }

        [BindProperty]
        public int Chapter { get; set; }



        public AddMangaPageModel(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                if (Picture != null)
                {
                    PicturePath = ProcessUploadFile();
                }

                DateTime? endDate = null;
                if (EndDate != null)
                {
                    endDate = DateTime.Parse(EndDate);
                }

                Entertainment = new Manga(Title, MainGenre, DateTime.Parse(StartDate), Author, Status, AlternateTitle, endDate, Synopsis, Description, PicturePath, Genre, Volume, Chapter);

                if (EntertainmentDAL.AddEntertainment(Entertainment))
                {
                    return Redirect("/AdminPage/AdminViewPage");
                }
                return Page();
            }
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
    }
}
