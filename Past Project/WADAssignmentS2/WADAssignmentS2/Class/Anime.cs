using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace WADAssignmentS2.Class
{
    public class Anime
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public string Studio { get; set; }
        public int Duration { get; set; }
        public string Synopsis { get; set; }
        public string Picture { get; set; }

        public Anime(int id, string title, string genre, string type, string studio, int duration, string synopsis, string picture)
        {
            ID = id;
            Title = title;
            Genre = genre;
            Type = type;
            Studio = studio;
            Duration = duration;
            Synopsis = synopsis;
            Picture = picture;
        }

        public string FirstGenre
        {
            get
            {
                var result = Regex.Match(Genre, @"^([\w\-]+)");
                return result.ToString();
                /*string firstGenre = String.Empty;

                // Check for empty string.
                if (String.IsNullOrEmpty(Genre))
                {
                    return string.Empty;
                }

                // Get first word from passed string
                firstGenre = Genre.Split(',').FirstOrDefault();
                if (String.IsNullOrEmpty(firstGenre))
                {
                    return string.Empty;
                }

                return firstGenre;*/
            }
        }

        public string GetDuration
        {
            get
            {
                string result = null;
                switch(this.Type)
                {
                    case "Movie":
                        {
                            if(Duration <= 60)
                            {
                                result = $"{Duration.ToString()} min.";
                            }
                            else
                            {
                                result = $"{(Duration/60).ToString()} hr. {(Duration%60).ToString()} min.";
                            }
                            break;
                        }
                    case "Shows":
                        {
                            result = $"{Duration.ToString()} min. per ep.";
                            break;
                        }
                }
                return result;
            }
        }
    }
}
