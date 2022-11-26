using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blue_Sakura_Application.Enum;

namespace Blue_Sakura_Application.Class
{
    public class Manga : Entertainment
    {
        private string author;//required
        private int volumes;//optional
        private int chapters;//optional

        public Manga(string title, GenreType mainGenre, DateTime startDate, string author,
                        EntertainmentStatusType? status = EntertainmentStatusType.COMING_SOON, string alternateTitle = null, DateTime? endDate = null, string synopsis = null, string description = null,
                        int volumes = 0, int chapters = 0) : 
                        base(title, mainGenre, startDate, status, alternateTitle, endDate, synopsis, description)
        {
            this.author = author;
            this.volumes = volumes;
            this.chapters = chapters;
        }

        public override string Type()
        { return "Manga"; }

        public string Auhor
        { get { return author; } set { author = value; } }
        public int Volumes
        { get { return volumes; } set { volumes = value; } }
        public int Chapters
        { get { return chapters; } set { chapters = value; } }
    }
}
