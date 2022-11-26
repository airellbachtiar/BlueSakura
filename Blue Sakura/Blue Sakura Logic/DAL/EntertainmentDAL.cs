using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.Parser;

namespace Blue_Sakura_Logic.DAL
{
    public static class EntertainmentDAL
    {
        private static string sql;

        public static List<Entertainment> GetAllEntertainment()
        {
            List<Entertainment> entertainments = new List<Entertainment>();
            entertainments.AddRange(GetAllAnime());
            entertainments.AddRange(GetAllManga());
            entertainments.Sort((x, y) => x.Id.CompareTo(y.Id));
            return entertainments;
        }

        private static List<Anime> GetAllAnime()
        {
            sql = "SELECT * FROM `entertainment` INNER JOIN `anime` ON entertainment.ID = anime.EntertainmentID";
            List<Anime> animes = new List<Anime>();
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>();
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return EntertainmentParsers.AnimeParserList(dataSet);

        }

        private static List<Manga> GetAllManga()
        {
            sql = "SELECT * FROM `entertainment` INNER JOIN `manga` ON entertainment.ID = manga.EntertainmentID";
            List<Manga> mangas = new List<Manga>();
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>();
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return EntertainmentParsers.MangaParserList(dataSet);
        }

        public static Anime GetAnime(int? id)
        {
            sql = "SELECT * FROM `entertainment` INNER JOIN `anime` ON entertainment.ID = anime.EntertainmentID WHERE entertainment.ID = @ID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("ID", id.ToString())
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return EntertainmentParsers.AnimeParser(dataSet);
        }

        public static Manga GetManga(int? id)
        {
            sql = "SELECT * FROM `entertainment` INNER JOIN `manga` ON entertainment.ID = manga.EntertainmentID WHERE entertainment.ID = @ID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("ID", id.ToString())
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return EntertainmentParsers.MangaParser(dataSet);
        }

        public static string GetEntertainmentType(int? entertainmentID)
        {
            sql = "SELECT * FROM `entertainment` WHERE ID = @ID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("ID", entertainmentID.ToString())
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            return EntertainmentParsers.GetEntertainmentType(dataSet);
        }

        public static Entertainment GetEntertainment(int? id)
        {
            Entertainment entertainment = null;
            if(id == null)
            {
                id = 0;
            }

            switch (GetEntertainmentType(id))
            {
                case "ANIME":
                    entertainment = GetAnime(id);
                    return entertainment;
                case "MANGA":
                    entertainment = GetManga(id);
                    return entertainment;
                default:
                    sql = "SELECT * FROM `entertainment` WHERE ID = @ID";
                    List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
                    {
                        new KeyValuePair<string, dynamic>("ID", id.ToString())
                    };
                    DataSet dataSet = DALController.ExecuteSql(sql, parameters);
                    entertainment = EntertainmentParsers.GetEntertainment(dataSet);
                    return entertainment;
            }

        }

        public static bool AddEntertainment(Entertainment entertainment)
        {
            if(IsTitleDuplicate(entertainment.Title))
            {
                return false;
            }

            sql = "INSERT INTO `entertainment` (`ID`, `Title`, `Genre`, `MainGenre`, `StartDate`, `Status`, `AlternateTitle`, `EndDate`, `Synopsis`, `Description`, `Picture`, `Type`) VALUES (NULL, @Title, @Genre, @MainGenre, @StartDate, @Status, @AlternateTitle, @EndDate, @Synopsis, @Description, @Picture, @Type)";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Title", entertainment.Title),
                new KeyValuePair<string, dynamic>("Genre", entertainment.Genre),
                new KeyValuePair<string, dynamic>("MainGenre", entertainment.MainGenre.ToString()),
                new KeyValuePair<string, dynamic>("StartDate", DateConverterToDB(entertainment.StartDate)),
                new KeyValuePair<string, dynamic>("Status", entertainment.Status.ToString()),
                new KeyValuePair<string, dynamic>("AlternateTitle", entertainment.AlternateTitle),
                new KeyValuePair<string, dynamic>("EndDate", DateConverterToDB(entertainment.EndDate)),
                new KeyValuePair<string, dynamic>("Synopsis", entertainment.Synopsis),
                new KeyValuePair<string, dynamic>("Description", entertainment.Description),
                new KeyValuePair<string, dynamic>("Picture", entertainment.Picture)
            };

            if(entertainment is Anime)
            {
                parameters.Add(new KeyValuePair<string, dynamic>("Type", "ANIME"));
                DALController.ExecuteInsert(sql, parameters);

                int entertainmentID = GetEntertainment(entertainment.Title).Id;
                sql = "INSERT INTO `anime` (`EntertainmentID`, `Studio`, `NrOfEpisode`, `Duration`, `Prequel`, `Sequel`) VALUES (@EntertainmentID, @Studio, @NrOfEpisode, @Duration, @Prequel, @Sequel)";
                parameters = new List<KeyValuePair<string, dynamic>>()
                {
                    new KeyValuePair<string, dynamic>("EntertainmentID", entertainmentID),
                    new KeyValuePair<string, dynamic>("Studio", ((Anime)entertainment).Studio),
                    new KeyValuePair<string, dynamic>("NrOfEpisode", ((Anime)entertainment).NrOfEpisode),
                    new KeyValuePair<string, dynamic>("Duration", ((Anime)entertainment).Duration),
                    new KeyValuePair<string, dynamic>("Prequel", ((Anime)entertainment).Prequel),
                    new KeyValuePair<string, dynamic>("Sequel", ((Anime)entertainment).Sequel)
                };
                DALController.ExecuteInsert(sql, parameters);
                return true;    
            }
            else if(entertainment is Manga)
            {
                parameters.Add(new KeyValuePair<string, dynamic>("Type", "MANGA"));
                DALController.ExecuteInsert(sql, parameters);

                int entertainmentID = GetEntertainment(entertainment.Title).Id;
                sql = "INSERT INTO `manga` (`EntertainmentID`, `Author`, `Volumes`, `Chapter`) VALUES (@EntertainmentID, @Author, @Volumes, @Chapter)";
                parameters = new List<KeyValuePair<string, dynamic>>()
                {
                    new KeyValuePair<string, dynamic>("EntertainmentID", entertainmentID),
                    new KeyValuePair<string, dynamic>("Author", ((Manga)entertainment).Author),
                    new KeyValuePair<string, dynamic>("Volumes", ((Manga)entertainment).Volumes),
                    new KeyValuePair<string, dynamic>("Chapter", ((Manga)entertainment).Chapters)
                };
                DALController.ExecuteInsert(sql, parameters);
                return true;
            }
            else
            {
                parameters.Add(new KeyValuePair<string, dynamic>("Type", ""));
                DALController.ExecuteInsert(sql, parameters);
                return true;
            }
        }

        public static bool IsTitleDuplicate(string title)
        {
            sql = "SELECT * FROM entertainment WHERE Title = @Title";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Title", title)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);

            if(dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private static Entertainment GetEntertainment(string title)
        {
            Entertainment entertainment = null;
            sql = "SELECT * FROM `entertainment` WHERE Title = @Title";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Title", title)
            };
            DataSet dataSet = DALController.ExecuteSql(sql, parameters);
            entertainment = EntertainmentParsers.GetEntertainment(dataSet);
            return entertainment;
        }

        private static DateTime? DateConverterToDB(DateTime? date)
        {
            if(date == null)
            {
                return null;
            }

            //26/08/2016 00:00:00
            string dateStr = date.ToString();
            dateStr = dateStr.Split(" ")[0];
            string[] newDate = dateStr.Split("/");
            dateStr = $"{newDate[2]}-{newDate[1]}-{newDate[0]}";
            //return DateTime.ParseExact(date, "dd-MM-yyyy", null);
            return DateTime.Parse(dateStr);
            /*DateTime dateTime = DateTime.ParseExact(date.ToString(), "dd/MM/yyyy", null);
            return DateTime.ParseExact(dateTime.ToString("dd/MM/yyyy"), "yyyy-MM-dd",null);*/
        }

        public static bool UpdateEntertainment(Entertainment entertainment)
        {
            sql = "UPDATE `entertainment` SET `Title` = @Title, `Genre` = @Genre, `MainGenre` = @MainGenre, `StartDate` = @StartDate, `Status` = @Status, `AlternateTitle` = @AlternateTitle, `EndDate` = @EndDate, `Synopsis` = @Synopsis, `Description` = @Description, `Picture` = @Picture WHERE `entertainment`.`ID` = @ID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("ID", entertainment.Id),
                new KeyValuePair<string, dynamic>("Title", entertainment.Title),
                new KeyValuePair<string, dynamic>("Genre", entertainment.Genre),
                new KeyValuePair<string, dynamic>("MainGenre", entertainment.MainGenre.ToString()),
                new KeyValuePair<string, dynamic>("StartDate", DateConverterToDB(entertainment.StartDate)),
                new KeyValuePair<string, dynamic>("Status", entertainment.Status.ToString()),
                new KeyValuePair<string, dynamic>("AlternateTitle", entertainment.AlternateTitle),
                new KeyValuePair<string, dynamic>("EndDate", DateConverterToDB(entertainment.EndDate)),
                new KeyValuePair<string, dynamic>("Synopsis", entertainment.Synopsis),
                new KeyValuePair<string, dynamic>("Description", entertainment.Description),
                new KeyValuePair<string, dynamic>("Picture", entertainment.Picture)
            };
            DALController.ExecuteInsert(sql, parameters);

            if (entertainment is Anime)
            {
                sql = "UPDATE `anime` SET `Studio` = @Studio, `NrOfEpisode` = @NrOfEpisode, `Duration` = @Duration, `Prequel` = @Prequel, `Sequel` = @Sequel WHERE `EntertainmentID` = @EntertainmentID";
                parameters = new List<KeyValuePair<string, dynamic>>()
                {
                    new KeyValuePair<string, dynamic>("Studio", ((Anime)entertainment).Studio),
                    new KeyValuePair<string, dynamic>("Duration", ((Anime)entertainment).Duration),
                    new KeyValuePair<string, dynamic>("NrOfEpisode", ((Anime)entertainment).NrOfEpisode),
                    new KeyValuePair<string, dynamic>("Prequel", ((Anime)entertainment).Prequel),
                    new KeyValuePair<string, dynamic>("Sequel", ((Anime)entertainment).Sequel),
                    new KeyValuePair<string, dynamic>("EntertainmentID", ((Anime)entertainment).Id)
                };
                DALController.ExecuteInsert(sql, parameters);
                return true;
            }
            else if (entertainment is Manga)
            {
                sql = "UPDATE `manga` SET `Author` = @Author, `Volumes` = @Volumes, `Chapter` = @Chapter WHERE `EntertainmentID` = @EntertainmentID";
                parameters = new List<KeyValuePair<string, dynamic>>()
                {
                    new KeyValuePair<string, dynamic>("Author", ((Manga)entertainment).Author),
                    new KeyValuePair<string, dynamic>("Volumes", ((Manga)entertainment).Volumes),
                    new KeyValuePair<string, dynamic>("Chapter", ((Manga)entertainment).Chapters),
                    new KeyValuePair<string, dynamic>("EntertainmentID", ((Manga)entertainment).Id)
                };
                DALController.ExecuteInsert(sql, parameters);
                return true;
            }
            return true;
        }

        public static bool RemoveEntertainment(int entertainmentID)
        {
            Entertainment entertainment = GetEntertainment(entertainmentID);
            sql = "DELETE FROM `Entertainment` WHERE `ID` = @ID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("ID", entertainment.Id)
            };
            DALController.ExecuteInsert(sql, parameters);
            return true;
        }
    }
}
