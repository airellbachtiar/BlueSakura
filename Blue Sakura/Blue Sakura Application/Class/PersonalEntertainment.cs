using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blue_Sakura_Application.Enum;

namespace Blue_Sakura_Application.Class
{
    public class PersonalEntertainment
    {
        private Entertainment entertainment;
        private PersonalStatusType status;
        private int progress;

        public PersonalEntertainment(Entertainment entertainment, PersonalStatusType status = PersonalStatusType.PLAN, int progress = 1)
        {
            this.entertainment = entertainment;
            this.status = status;
            this.progress = progress;
        }

        public Entertainment Entertainment
        { get { return entertainment; } set { entertainment = value; } }

        public PersonalStatusType Status
        { get { return status; } set { status = value; } }

        public int Progress
        { get { return progress; } set { progress = value; } }
    }
}
