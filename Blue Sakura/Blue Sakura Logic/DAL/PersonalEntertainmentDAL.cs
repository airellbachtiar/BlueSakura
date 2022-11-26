using Blue_Sakura_Logic.Parser;
using Blue_Sakura_Logic.PersonalEntertainmentCollection;
using Blue_Sakura_Logic.UserCollection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Sakura_Logic.DAL
{
    public static class PersonalEntertainmentDAL
    {
        private static string sql;

        public static List<PersonalEntertainment> GetAllPersonalEntertainments(int userID)
        {
            int listID = GetPersonalListID(userID);
            sql = "SELECT * FROM personallist WHERE ID = @listID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("listID", listID)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return PersonalEntertainmentParsers.PersonalEntertainmentParserList(dataSet);
        }

        public static PersonalEntertainment GetPersonalEntertainment(int userID, int entertainmentID)
        {
            int listID = GetPersonalListID(userID);
            sql = "SELECT * FROM personallist WHERE ID = @listID AND EntertainmentID = @EntertainmentID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("listID", listID),
                new KeyValuePair<string, dynamic>("EntertainmentID", entertainmentID)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return PersonalEntertainmentParsers.PersonalEntertainmentParser(dataSet);
        }

        public static bool AddEntertainmentToPersonalEntertainment(User user, PersonalEntertainment personalEntertainment)
        {
            //check duplicate entertainment
            if(IsPersonalEntertainmnetDuplicate((int)user.PersonalListID, personalEntertainment.EntertainmentID))
            {
                return false;
            }

            //add entertainment to personal list
            sql = "INSERT INTO `personallist` (`ID`, `EntertainmentID`, `Status`, `Progress`) VALUES (@PersonalListID, @EntertainmentID, @Status, @Progress)";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("PersonalListID", user.PersonalListID),
                new KeyValuePair<string, dynamic>("EntertainmentID", personalEntertainment.EntertainmentID),
                new KeyValuePair<string, dynamic>("Status", personalEntertainment.Status.ToString()),
                new KeyValuePair<string, dynamic>("Progress", personalEntertainment.Progress)
            };
            DALController.ExecuteInsert(sql, parameters);
            return true;
        }

        public static void UpdatePersonalEntertainment(User user, PersonalEntertainment personalEntertainment)
        {
            sql = "UPDATE `personallist` SET `Status` = @Status, `Progress` = @Progress WHERE `ID` = @PersonalListID AND `EntertainmentID` = @EntertainmentID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("PersonalListID", user.PersonalListID),
                new KeyValuePair<string, dynamic>("EntertainmentID", personalEntertainment.EntertainmentID),
                new KeyValuePair<string, dynamic>("Status", personalEntertainment.Status.ToString()),
                new KeyValuePair<string, dynamic>("Progress", personalEntertainment.Progress)
            };
            DALController.ExecuteInsert(sql, parameters);
        }

        public static void RemovePersonalEntertainment(User user, int entertainmentID)
        {
            sql = "DELETE FROM `personallist` WHERE `ID` = @PersonalListID AND `EntertainmentID` = @EntertainmentID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("PersonalListID", user.PersonalListID),
                new KeyValuePair<string, dynamic>("EntertainmentID", entertainmentID)
            };
            DALController.ExecuteInsert(sql, parameters);
        }

        public static int GetPersonalListID(int userID)
        {
            sql = "SELECT PersonalListID FROM usertopersonallist WHERE UserID = @ID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("ID", userID)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return PersonalEntertainmentParsers.UserToPersonalListIDParser(dataSet);
        }

        //Personal Entertainment list setup in database
        public static void AsssignPersonalEntertainment(int UserID)
        {
            sql = "INSERT INTO `usertopersonallist` (`PersonalListID`, `UserID`) VALUES (NULL, @ID)";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("ID", UserID.ToString())
            };
            DALController.ExecuteInsert(sql, parameters);
        }

        private static bool IsPersonalEntertainmnetDuplicate(int personalListID ,int entertainmentID)
        {
            sql = "SELECT * FROM personallist WHERE ID = @PersonalListID AND EntertainmentID = @EntertainmentID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("PersonalListID", personalListID),
                new KeyValuePair<string, dynamic>("EntertainmentID", entertainmentID)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
