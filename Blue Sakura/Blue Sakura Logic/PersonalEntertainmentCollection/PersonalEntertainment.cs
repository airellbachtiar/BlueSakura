using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blue_Sakura_Logic.EnumCollection;
using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.DAL;

namespace Blue_Sakura_Logic.PersonalEntertainmentCollection
{
    public class PersonalEntertainment
    {
        private int entertainmentID;
        private PersonalStatusType status;
        private int progress;


        public PersonalEntertainment(int entertainmentID, PersonalStatusType status = PersonalStatusType.PLAN, int progress = 1)
        {
            this.status = status;
            this.progress = progress;

            this.entertainmentID = entertainmentID;
        }

        public int EntertainmentID
        { get { return entertainmentID; } set { entertainmentID = value; } }

        public PersonalStatusType Status
        { get { return status; } set { status = value; } }

        public int Progress
        { get { return progress; } set { progress = value; } }
    }
}
