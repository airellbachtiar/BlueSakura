using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Blue_Sakura_Logic.UserCollection;
using Blue_Sakura_Logic.Parser;

namespace Blue_Sakura_Logic.DAL
{
    public static class UserDAL
    {
        private static string sql;

        public static List<User> GetAllUsers()
        {
            sql = "SELECT * FROM user";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>();
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return UserParsers.UserParserList(dataSet);
        }

        public static bool AddUser(User user)
        {
            if(IsUsernameDuplicate(user))
            {
                return false;
            }

            //add user
            sql = "INSERT INTO `user` (`ID`, `Name`, `Username`, `Email`, `Password`, `Salt`, `Picture`,`PersonalListID`) VALUES (NULL, NULL, @Username, @Email, @Password, @Salt, @Picture, NULL)";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Name", user.Name),
                new KeyValuePair<string, dynamic>("Username", user.Username),
                new KeyValuePair<string, dynamic>("Email", user.Email),
                new KeyValuePair<string, dynamic>("Password", user.Password),
                new KeyValuePair<string, dynamic>("Salt", user.Salt),
                new KeyValuePair<string, dynamic>("Picture", user.Picture)
            };
            DALController.ExecuteInsert(sql, parameters);

            //update User to get user id
            user = GetUser(user.Username);

            //assign new empty personal list
            PersonalEntertainmentDAL.AsssignPersonalEntertainment(user.Id);

            //get personal list ID
            int personalListID = PersonalEntertainmentDAL.GetPersonalListID(user.Id);

            //assign personal list to user database
            sql = "UPDATE `user` SET `PersonalListID` = @ListID WHERE `ID` = @UserID";
            parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("ListID", personalListID),
                new KeyValuePair<string, dynamic>("UserID", user.Id)
            };
            DALController.ExecuteInsert(sql, parameters);

            return true;
        }

        public static void UpdateUserWithPassword(User user)
        {
            sql = "UPDATE `user` SET `Name` = @Name, `Username` = @Username, `Email` = @Email, `Password` = @Password, `Picture` = @Picture WHERE `user`.`ID` = @ID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Name", user.Name),
                new KeyValuePair<string, dynamic>("Username", user.Username),
                new KeyValuePair<string, dynamic>("Email", user.Email),
                new KeyValuePair<string, dynamic>("Password", user.Password),
                new KeyValuePair<string, dynamic>("Picture", user.Picture),
                new KeyValuePair<string, dynamic>("ID", user.Id)
            };
            DALController.ExecuteInsert(sql, parameters);
        }

        public static void UpdateUser(User user)
        {
            sql = "UPDATE `user` SET `Name` = @Name, `Username` = @Username, `Email` = @Email, `Picture` = @Picture WHERE `user`.`ID` = @ID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Name", user.Name),
                new KeyValuePair<string, dynamic>("Username", user.Username),
                new KeyValuePair<string, dynamic>("Email", user.Email),
                new KeyValuePair<string, dynamic>("Picture", user.Picture),
                new KeyValuePair<string, dynamic>("ID", user.Id)
            };
            DALController.ExecuteInsert(sql, parameters);
        }

        public static User GetUser(int? id)
        {
            sql = "SELECT * FROM user WHERE ID = @ID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("ID", id)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return UserParsers.UserParser(dataSet);
        }

        public static User GetUser(string username)
        {
            sql = "SELECT * FROM user WHERE Username = @Username";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Username", username)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return UserParsers.UserParser(dataSet);
        }

        private static bool IsUsernameDuplicate(User user)
        {
            sql = "SELECT * FROM user WHERE Username = @Username";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Username", user.Username)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);

            if(dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static List<User> SearchUser(string searchInput)
        {
            string search = $"'%{searchInput}%'";
            sql = $"SELECT * FROM user WHERE Username LIKE {search}";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                //new KeyValuePair<string, dynamic>("Input", search)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return UserParsers.UserParserList(dataSet);
        }
    }
}
