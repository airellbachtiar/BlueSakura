using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Blue_Sakura_Logic.EnumCollection;

namespace Blue_Sakura_Logic.EntertainmentCollection
{
    public class Entertainment
    {
        private static int idCounter = 1;
        private int id;
        private string title;//required
        private GenreType mainGenre;//required
        private DateTime startDate;//required

        private EntertainmentStatusType? status;//optional
        private string alternateTitle;//optional
        private DateTime? endDate;//optional
        private string synopsis;//optional
        private string description;//optional
        private string picture;//optional
        private string genre;

        public Entertainment(string title, GenreType mainGenre, DateTime startDate,
                                EntertainmentStatusType? status = EntertainmentStatusType.COMING_SOON, string alternateTitle = null, DateTime? endDate = null, string synopsis = null, string description = null, string picture = "default.png", string genre = null)
        {
            id = idCounter;
            idCounter = idCounter + 1;//id changed

            this.title = title;
            this.mainGenre = mainGenre;
            this.startDate = startDate;
            this.status = status;
            if(status == null)
            {
                status = EntertainmentStatusType.COMING_SOON;
            }
            this.alternateTitle = alternateTitle;
            this.endDate = endDate;
            this.synopsis = synopsis;
            this.description = description;
            this.picture = picture;
            this.genre = genre;
        }

        public Entertainment(int id, string title, GenreType mainGenre, DateTime startDate,
                                EntertainmentStatusType? status = EntertainmentStatusType.COMING_SOON, string alternateTitle = null, DateTime? endDate = null, string synopsis = null, string description = null, string picture = "default.png", string genre = null)
        {
            this.id = id;
            this.title = title;
            this.mainGenre = mainGenre;
            this.startDate = startDate;
            this.status = status;
            if (status == null)
            {
                status = EntertainmentStatusType.COMING_SOON;
            }
            this.alternateTitle = alternateTitle;
            this.endDate = endDate;
            this.synopsis = synopsis;
            this.description = description;
            this.picture = picture;
            this.genre = genre;
        }

        public void UpdateCounter(List<Entertainment> entertainments)
        {
            int i = 0;
            foreach (Entertainment e in entertainments)
            {
                if (i < e.Id)
                {
                    i = e.Id;
                }
            }
            idCounter = i + 1;
        }

        public int Id
        { get { return id; } }

        public string Title
        { get { return title; } set { title = value; } }

        public GenreType MainGenre
        { get { return mainGenre; } set { mainGenre = value; } }

        public DateTime StartDate
        { get { return startDate; } set { startDate = value; } }

        public EntertainmentStatusType? Status
        { get { return status; } set { status = value; } }

        public string AlternateTitle
        { get { return alternateTitle; } set { alternateTitle = value; } }

        public DateTime? EndDate
        { get { return endDate; } set { endDate = value; } }

        public string Synopsis
        { get { return synopsis; } set { synopsis = value; } }

        public string Description
        { get { return description; } set { synopsis = value; } }

        public string Picture
        { get { return picture; } set { picture = value; } }

        public virtual string Type()
        {
            return null;
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            set { genre = value; }
        }

        public string GetMainGenre()
        {

            return FormatChanger(mainGenre.ToString());
        }

        public string GetStatus()
        {
            return FormatChanger(status.ToString());
        }

        private string FormatChanger(string input)
        {
            /*var result = Regex.Match(Genre, @"^([\w\-]+)");
                return result.ToString();*/
            string[] splitResult = input.ToString().Split('_');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < splitResult.Count(); i++)
            {
                sb.Append(splitResult[i].Substring(0, 1));
                sb.Append(splitResult[i].Substring(1).ToLower());
                if (i < splitResult.Count() - 1)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        public string GetStartDate { get { return startDate.ToString("dd/MM/yyyy"); } }
        public string GetEndDate 
        { 
            get 
            {
                if (endDate != null)
                {
                    return endDate.Value.ToString("dd/MM/yyyy");
                }
                return null;
            } 
        }
    }
}
