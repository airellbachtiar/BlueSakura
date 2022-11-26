using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blue_Sakura_Logic.EnumCollection;

namespace Blue_Sakura_Logic.EntertainmentCollection
{
    public class Anime : Entertainment
    {
        private string studio;//required
        private int nrOfEpisode;//semi-optional
        private int duration;//optional
        private int? prequel;//optional
        private int? sequel;//optional

        //new anime
        public Anime(string title, GenreType mainGenre, DateTime startDate, string studio,
                        EntertainmentStatusType? status = EntertainmentStatusType.COMING_SOON, string alternateTitle = null, DateTime? endDate = null, string synopsis = null, string description = null, string picture = "default.png", string genre = null,
                        int nrOfEpisode = 1, int duration = 0, int? prequel = null, int? sequel = null) : 
                        base(title, mainGenre, startDate, status, alternateTitle, endDate, synopsis, description, picture, genre)
        {
            this.studio = studio;
            this.nrOfEpisode = nrOfEpisode;
            this.duration = duration;
            this.prequel = prequel;
            this.sequel = sequel;
            if(picture == null)
            {
                this.Picture = "default.png";
            }
        }

        //add existing Anime
        public Anime(int id, string title, GenreType mainGenre, DateTime startDate, string studio,
                        EntertainmentStatusType? status = EntertainmentStatusType.COMING_SOON, string alternateTitle = null, DateTime? endDate = null, string synopsis = null, string description = null, string picture = "default.png", string genre = null,
                        int nrOfEpisode = 1, int duration = 0, int? prequel = null, int? sequel = null) :
                        base(id, title, mainGenre, startDate, status, alternateTitle, endDate, synopsis, description, picture, genre)
        {
            this.studio = studio;
            this.nrOfEpisode = nrOfEpisode;
            this.duration = duration;
            this.prequel = prequel;
            this.sequel = sequel;
            if (picture == null)
            {
                this.Picture = "default.png";
            }
        }

        public override string Type()
        { return "Anime";}

        public string Studio
        { get { return studio; } set { studio = value; } }
        public int NrOfEpisode 
        { get { return nrOfEpisode; } set { nrOfEpisode = value; } }
        public int Duration
        { get { return duration; } set { duration = value; } }
        public int? Prequel
        { get { return prequel; } set { prequel = value; } }
        public int? Sequel
        { get { return sequel; } set { sequel = value; } }

        public string GetDuration
        {
            get
            {
                string result = null;
                switch (NrOfEpisode)
                {
                    case 1:
                        {
                            StringBuilder sb;
                            if (Duration <= 60)
                            {
                                sb = new StringBuilder(Duration.ToString());
                            }
                            else
                            {
                                string hour = (Duration / 60).ToString();
                                string minute = (Duration % 60).ToString();
                                sb = new StringBuilder(hour);
                                sb.Append(" hr. ");
                                sb.Append(minute);
                            }
                            sb.Append(" min.");
                            result = sb.ToString();
                            break;
                        }
                    case > 1:
                        {
                            StringBuilder sb = new StringBuilder(Duration.ToString());
                            sb.Append(" min. per ep.");
                            result = sb.ToString();
                            break;
                        }
                }
                return result;
            }
        }
    }
}
