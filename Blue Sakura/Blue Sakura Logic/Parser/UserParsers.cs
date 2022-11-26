using Blue_Sakura_Logic.UserCollection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Sakura_Logic.Parser
{
    public static class UserParsers
    {
        public static List<User> UserParserList(DataSet dataSet)
        {
            List<User> users = new List<User>();
            for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
            {
                int id = Convert.ToInt32(dataSet.Tables[0].Rows[row]["ID"]);
                string name = DBNullConverter(dataSet.Tables[0].Rows[row]["Name"].ToString());
                string username = dataSet.Tables[0].Rows[row]["Username"].ToString();
                string email = dataSet.Tables[0].Rows[row]["Email"].ToString();
                string password = dataSet.Tables[0].Rows[row]["Password"].ToString();
                string salt = dataSet.Tables[0].Rows[row]["Salt"].ToString();
                string picture = DBNullConverter(dataSet.Tables[0].Rows[row]["Picture"].ToString());
                int? personalListID = Convert.ToInt32(DBNullConverter(dataSet.Tables[0].Rows[row]["PersonalListID"].ToString()));

                User user = new User(id, name, email, username, password, salt, picture, personalListID);
                if (dataSet.Tables[0].Rows[row]["Type"].ToString() == "Admin")
                {
                    user.IsAdmin = true;
                }
                users.Add(user);
            }
            return users;
        }

        public static User UserParser(DataSet dataSet)
        {
            User user = null;

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ID"]);
                string name = DBNullConverter(dataSet.Tables[0].Rows[0]["Name"].ToString());
                string username = dataSet.Tables[0].Rows[0]["Username"].ToString();
                string email = dataSet.Tables[0].Rows[0]["Email"].ToString();
                string password = dataSet.Tables[0].Rows[0]["Password"].ToString();
                string salt = dataSet.Tables[0].Rows[0]["Salt"].ToString();
                string picture = DBNullConverter(dataSet.Tables[0].Rows[0]["Picture"].ToString());
                int? personalListID = Convert.ToInt32(DBNullConverter(dataSet.Tables[0].Rows[0]["PersonalListID"].ToString()));

                user = new User(id, name, email, username, password, salt, picture, personalListID);
                if (dataSet.Tables[0].Rows[0]["Type"].ToString() == "Admin")
                {
                    user.IsAdmin = true;
                }
                return user;
            }
            else
            {
                return user;
            }
        }

        private static string DBNullConverter(string val)
        {
            if (val == DBNull.Value.ToString())
            {
                val = null;
            }
            return val;
        }
    }
}
