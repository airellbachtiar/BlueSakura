using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.EnumCollection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Sakura_Logic.Parser
{
    public static class EntertainmentParsers
    {
        public static List<Anime> AnimeParserList(DataSet dataSet)
        {
            List<Anime> animes = new List<Anime>();

            for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
            {
                int id = Convert.ToInt32(dataSet.Tables[0].Rows[row]["ID"]);
                string title = dataSet.Tables[0].Rows[row]["Title"].ToString();
                string genre = dataSet.Tables[0].Rows[row]["Genre"].ToString();//not yet
                GenreType mainGenre = (GenreType)Enum.Parse(typeof(GenreType), dataSet.Tables[0].Rows[row]["MainGenre"].ToString());
                DateTime startDate = DateTime.Parse(dataSet.Tables[0].Rows[row]["StartDate"].ToString());
                EntertainmentStatusType status = (EntertainmentStatusType)Enum.Parse(typeof(EntertainmentStatusType), dataSet.Tables[0].Rows[row]["Status"].ToString());
                string alternateTitle = dataSet.Tables[0].Rows[row]["AlternateTitle"].ToString();
                DateTime? endDate = EndDateConverterToClass(dataSet.Tables[0].Rows[row]["EndDate"].ToString());
                string synopsis = dataSet.Tables[0].Rows[row]["Synopsis"].ToString();
                string description = dataSet.Tables[0].Rows[row]["Description"].ToString();
                string picture = dataSet.Tables[0].Rows[row]["Picture"].ToString();
                string studio = dataSet.Tables[0].Rows[row]["Studio"].ToString();
                int nrOfEpisode = Convert.ToInt32(dataSet.Tables[0].Rows[row]["NrOfEpisode"]);
                int duration = Convert.ToInt32(dataSet.Tables[0].Rows[row]["Duration"]);
                int? prequel = Convert.ToInt32(DBNullConverter(dataSet.Tables[0].Rows[row]["Prequel"].ToString()));
                int? sequel = Convert.ToInt32(DBNullConverter(dataSet.Tables[0].Rows[row]["Sequel"].ToString()));

                animes.Add(new Anime(id, title, mainGenre, startDate, studio, status, alternateTitle, endDate, synopsis, description, picture, genre, nrOfEpisode, duration, prequel, sequel));
            }
            return animes;
        }

        public static Anime AnimeParser(DataSet dataSet)
        {
            Anime anime = null;

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ID"]);
                string title = dataSet.Tables[0].Rows[0]["Title"].ToString();
                string genre = dataSet.Tables[0].Rows[0]["Genre"].ToString();//not yet
                GenreType mainGenre = (GenreType)Enum.Parse(typeof(GenreType), dataSet.Tables[0].Rows[0]["MainGenre"].ToString());
                DateTime startDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["StartDate"].ToString());
                EntertainmentStatusType status = (EntertainmentStatusType)Enum.Parse(typeof(EntertainmentStatusType), dataSet.Tables[0].Rows[0]["Status"].ToString());
                string alternateTitle = dataSet.Tables[0].Rows[0]["AlternateTitle"].ToString();
                DateTime? endDate = EndDateConverterToClass(dataSet.Tables[0].Rows[0]["EndDate"].ToString());
                string synopsis = dataSet.Tables[0].Rows[0]["Synopsis"].ToString();
                string description = dataSet.Tables[0].Rows[0]["Description"].ToString();
                string picture = dataSet.Tables[0].Rows[0]["Picture"].ToString();
                string studio = dataSet.Tables[0].Rows[0]["Studio"].ToString();
                int nrOfEpisode = Convert.ToInt32(dataSet.Tables[0].Rows[0]["NrOfEpisode"]);
                int duration = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Duration"]);
                int? prequel = Convert.ToInt32(DBNullConverter(dataSet.Tables[0].Rows[0]["Prequel"].ToString()));
                int? sequel = Convert.ToInt32(DBNullConverter(dataSet.Tables[0].Rows[0]["Sequel"].ToString()));

                anime = new Anime(id, title, mainGenre, startDate, studio, status, alternateTitle, endDate, synopsis, description, picture, genre, nrOfEpisode, duration, prequel, sequel);
                return anime;
            }
            else
            {
                return anime;
            }
        }

        public static List<Manga> MangaParserList(DataSet dataSet)
        {
            List<Manga> mangas = new List<Manga>();

            for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
            {
                int id = Convert.ToInt32(dataSet.Tables[0].Rows[row]["ID"]);
                string title = dataSet.Tables[0].Rows[row]["Title"].ToString();
                string genre = dataSet.Tables[0].Rows[row]["Genre"].ToString();//not yet
                GenreType mainGenre = (GenreType)Enum.Parse(typeof(GenreType), dataSet.Tables[0].Rows[row]["MainGenre"].ToString());
                DateTime startDate = DateTime.Parse(dataSet.Tables[0].Rows[row]["StartDate"].ToString());
                EntertainmentStatusType status = (EntertainmentStatusType)Enum.Parse(typeof(EntertainmentStatusType), dataSet.Tables[0].Rows[row]["Status"].ToString());
                string alternateTitle = dataSet.Tables[0].Rows[row]["AlternateTitle"].ToString();
                DateTime? endDate = EndDateConverterToClass(dataSet.Tables[0].Rows[row]["EndDate"].ToString());
                string synopsis = dataSet.Tables[0].Rows[row]["Synopsis"].ToString();
                string description = dataSet.Tables[0].Rows[row]["Description"].ToString();
                string picture = dataSet.Tables[0].Rows[row]["Picture"].ToString();
                string author = dataSet.Tables[0].Rows[row]["Author"].ToString();
                int? volumes = Convert.ToInt32(DBNullConverter(dataSet.Tables[0].Rows[0]["Volumes"].ToString()));
                int? chapter = Convert.ToInt32(DBNullConverter(dataSet.Tables[0].Rows[0]["Chapter"].ToString()));

                mangas.Add(new Manga(id, title, mainGenre, startDate, author, status, alternateTitle, endDate, synopsis, description, picture, genre, volumes, chapter));
            }

            return mangas;
        }

        public static Manga MangaParser(DataSet dataSet)
        {
            Manga manga = null;

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ID"]);
                string title = dataSet.Tables[0].Rows[0]["Title"].ToString();
                string genre = dataSet.Tables[0].Rows[0]["Genre"].ToString();//not yet
                GenreType mainGenre = (GenreType)Enum.Parse(typeof(GenreType), dataSet.Tables[0].Rows[0]["MainGenre"].ToString());
                DateTime startDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["StartDate"].ToString());
                EntertainmentStatusType status = (EntertainmentStatusType)Enum.Parse(typeof(EntertainmentStatusType), dataSet.Tables[0].Rows[0]["Status"].ToString());
                string alternateTitle = dataSet.Tables[0].Rows[0]["AlternateTitle"].ToString();
                DateTime? endDate = EndDateConverterToClass(dataSet.Tables[0].Rows[0]["EndDate"].ToString());
                string synopsis = dataSet.Tables[0].Rows[0]["Synopsis"].ToString();
                string description = dataSet.Tables[0].Rows[0]["Description"].ToString();
                string picture = dataSet.Tables[0].Rows[0]["Picture"].ToString();
                string author = dataSet.Tables[0].Rows[0]["Author"].ToString();
                int volumes = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Volumes"]);
                int chapter = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Chapter"]);

                manga = new Manga(id, title, mainGenre, startDate, author, status, alternateTitle, endDate, synopsis, description, picture, genre , volumes, chapter);

            }

            return manga;
        }

        public static string GetEntertainmentType(DataSet dataSet)
        {
            string type = null;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                type = dataSet.Tables[0].Rows[0]["Type"].ToString();
            }
            return type;
        }

        public static Entertainment GetEntertainment(DataSet dataSet)
        {
            Entertainment entertainment = null;

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ID"]);
                string title = dataSet.Tables[0].Rows[0]["Title"].ToString();
                string genre = dataSet.Tables[0].Rows[0]["Genre"].ToString();//not yet
                GenreType mainGenre = (GenreType)Enum.Parse(typeof(GenreType), dataSet.Tables[0].Rows[0]["MainGenre"].ToString());
                DateTime startDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["StartDate"].ToString());
                EntertainmentStatusType status = (EntertainmentStatusType)Enum.Parse(typeof(EntertainmentStatusType), dataSet.Tables[0].Rows[0]["Status"].ToString());
                string alternateTitle = dataSet.Tables[0].Rows[0]["AlternateTitle"].ToString();
                DateTime? endDate = EndDateConverterToClass(dataSet.Tables[0].Rows[0]["EndDate"].ToString());
                string synopsis = dataSet.Tables[0].Rows[0]["Synopsis"].ToString();
                string description = dataSet.Tables[0].Rows[0]["Description"].ToString();
                string picture = dataSet.Tables[0].Rows[0]["Picture"].ToString();

                entertainment = new Entertainment(id, title, mainGenre, startDate, status, alternateTitle, endDate, synopsis, description, picture);
                return entertainment;
            }
            return entertainment;
        }

        public static DateTime? EndDateConverterToClass(string date)
        {
            /*//26/08/2016 00:00:00
            date = date.Split(" ")[0];
            string[] newDate = date.Split("/");
            date = $"{newDate[0]}-{newDate[1]}-{newDate[2]}";
            //return DateTime.ParseExact(date, "dd-MM-yyyy", null);
            return DateTime.Parse(date);*/

            if(date == null || date == "")
            {
                return null;
            }

            return DateTime.Parse(date);
        }

        public static DateTime DateConverterToDB(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd", null);
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
