using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blue_Sakura_Application.Enum;

namespace Blue_Sakura_Application.Class
{
    public class Anime : Entertainment
    {
        private string studio;//required
        private int nrOfEpisode;//semi-optional
        private int duration;//optional
        private Anime prequel;//optional
        private Anime sequel;//optional

        public Anime(string title, GenreType mainGenre, DateTime startDate, string studio,
                        EntertainmentStatusType? status = EntertainmentStatusType.COMING_SOON, string alternateTitle = null, DateTime? endDate = null, string synopsis = null, string description = null,
                        int nrOfEpisode = 1, int duration = 0, Anime prequel = null, Anime sequel = null) : 
                        base(title, mainGenre, startDate, status, alternateTitle, endDate, synopsis, description)
        {
            this.studio = studio;
            this.nrOfEpisode = nrOfEpisode;
            this.duration = duration;
            this.prequel = prequel;
            this.sequel = sequel;
        }

        public override string Type()
        { return "Anime";}

        public string Studio
        { get { return studio; } set { studio = value; } }
        public int NrOfEpisode 
        { get { return nrOfEpisode; } set { nrOfEpisode = value; } }
        public int Duration
        { get { return duration; } set { duration = value; } }
        public Anime Prequel
        { get { return prequel; } set { prequel = value; } }
        public Anime Sequel
        { get { return sequel; } set { sequel = value; } }
    }
}
