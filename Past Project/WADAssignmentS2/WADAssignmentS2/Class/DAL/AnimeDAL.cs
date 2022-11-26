using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;

namespace WADAssignmentS2.Class.DAL
{
    public static class AnimeDAL
    {
        private static string sql;

        public static List<Anime> GetAllAnimes()
        {
            sql = "SELECT * FROM anime";

            List<Anime> animes = new List<Anime>();

            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>> { };
                DataSet dataSet = DALController.ExecuteSql(sql, parameters);

                for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
                {
                    int id = (int)dataSet.Tables[0].Rows[row]["ID"];
                    string title = (string)dataSet.Tables[0].Rows[row]["Title"];
                    string genre = (string)dataSet.Tables[0].Rows[row]["Genre"];
                    string type = (string)dataSet.Tables[0].Rows[row]["Type"];
                    string studio = (string)dataSet.Tables[0].Rows[row]["Studio"];
                    int duration = (int)dataSet.Tables[0].Rows[row]["Duration"];
                    string synopsis = (string)dataSet.Tables[0].Rows[row]["Synopsis"];
                    string picture = (string)dataSet.Tables[0].Rows[row]["Picture"];

                    animes.Add(new Anime(id, title, genre, type, studio, duration, synopsis, picture));
                }
            }
            catch(Exception)
            {
                
            }
            return animes;
        }

        public static Anime GetAnime(int id)
        {
            Anime anime = null;
            foreach(Anime a in GetAllAnimes())
            {
                if(a.ID == id)
                {
                    anime = a;
                }
            }
            return anime;
        }
    }
}
