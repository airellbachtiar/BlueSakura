using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blue_Sakura_Application.Enum;

namespace Blue_Sakura_Application.Class
{
    public abstract class Entertainment
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

        public Entertainment(string title, GenreType mainGenre, DateTime startDate,
                                EntertainmentStatusType? status = EntertainmentStatusType.COMING_SOON, string alternateTitle = null, DateTime? endDate = null, string synopsis = null, string description = null)
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
        }

        public void UpdateCounter(List<Entertainment> entertainments)
        {
            int i = 0;
            foreach (Entertainment e in entertainments)
            {
                if(i < e.Id)
                {
                    i = e.Id;
                }
            }
            idCounter = i+1;
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

        public abstract string Type();
    }
}
