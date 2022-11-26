using Blue_Sakura_Logic.EnumCollection;
using Blue_Sakura_Logic.PersonalEntertainmentCollection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Sakura_Logic.Parser
{
    public static class PersonalEntertainmentParsers
    {
        public static List<PersonalEntertainment> PersonalEntertainmentParserList(DataSet dataSet)
        {
            List<PersonalEntertainment> personalEntertainments = new List<PersonalEntertainment>();
            for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
            {
                //int id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ID"]);
                int EntertainmentID = Convert.ToInt32(dataSet.Tables[0].Rows[row]["EntertainmentID"]);
                PersonalStatusType status = (PersonalStatusType)Enum.Parse(typeof(PersonalStatusType), dataSet.Tables[0].Rows[row]["Status"].ToString());
                int progress = Convert.ToInt32(dataSet.Tables[0].Rows[row]["Progress"]);

                PersonalEntertainment personalEntertainment = new PersonalEntertainment(EntertainmentID, status, progress);
                personalEntertainments.Add(personalEntertainment);
            }
            return personalEntertainments;
        }

        public static PersonalEntertainment PersonalEntertainmentParser(DataSet dataSet)
        {
            PersonalEntertainment personalEntertainment = null;

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ID"]);
                int EntertainmentID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["EntertainmentID"]);
                PersonalStatusType status = (PersonalStatusType)Enum.Parse(typeof(PersonalStatusType), dataSet.Tables[0].Rows[0]["Status"].ToString());
                int progress = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Progress"]);

                personalEntertainment = new PersonalEntertainment(EntertainmentID, status, progress);
                return personalEntertainment;
            }
            else
            {
                return personalEntertainment;
            }
        }
        public static int UserToPersonalListIDParser(DataSet dataSet)
        {
            int personalListID = 0;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                personalListID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PersonalListID"]);
            }
            return personalListID;
        }

    }
}
