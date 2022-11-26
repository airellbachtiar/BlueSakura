using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;

namespace WADAssignmentS2.Class.DAL
{
    public static class UserDAL
    {
        private static string sql;

        public static List<User> GetAllUsers()
        {
            sql = "SELECT * FROM user";
            List<User> users = new List<User>();

            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>();
                DataSet dataSet = DALController.ExecuteSql(sql, parameters);

                for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
                {
                    int id = (int)dataSet.Tables[0].Rows[row]["ID"];
                    string name = dataSet.Tables[0].Rows[row]["Name"].ToString();
                    string username = (string)dataSet.Tables[0].Rows[row]["Username"];
                    string email = (string)dataSet.Tables[0].Rows[row]["Email"];
                    string password = (string)dataSet.Tables[0].Rows[row]["Password"];
                    string picture = dataSet.Tables[0].Rows[row]["Picture"].ToString();

                    users.Add(new User(id, name, username, email, password, picture));
                }
            }
            catch (Exception)
            {

            }
            return users;
        }

        public static void AddUser(User user)
        {
            sql = "INSERT INTO `user` (`ID`, `Name`, `Username`, `Email`, `Password`, `Picture`,`AnimeListID`) VALUES (NULL, NULL, @Username, @Email, @Password, NULL, NULL)";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                
            };
            DALController.ExecuteInsert(sql, parameters);
        }

        public static void UpdateUser(User user)
        {
            sql = "UPDATE";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {

            };
            DALController.ExecuteInsert(sql, parameters);
        }

        public static User GetUser(int? id)
        {
            User user = null;
            foreach(User u in GetAllUsers())
            {
                if(u.ID == id)
                {
                    user = u;
                }    
            }
            return user;
        }
    }
}
