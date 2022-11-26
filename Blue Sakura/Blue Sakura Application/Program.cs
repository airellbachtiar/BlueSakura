using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Blue_Sakura_Application.Class;
using Blue_Sakura_Application.Enum;

namespace Blue_Sakura_Application
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AllUser users = new AllUser();
            AllEntertainment entertainments = new AllEntertainment();

            users.addUser(new User("airell.bachtiar@gmail.com", "airell", "1"));
            users.addUser(new User("airell.bachtiar@gmail.com", "a", "1"));
            users.addUser(new User("airell.bachtiar@gmail.com", "b", "2"));

            users.GetUser(1).IsAdmin = true;

            entertainments.AddEntertainment(new Anime("Kimi no Na wa.", GenreType.ROMANCE, Convert.ToDateTime("26/08/2016"), "CoMix Wave Film", EntertainmentStatusType.COMPLETED, "Your Name.", Convert.ToDateTime("26/08/2016"), null, null, 1, 106));
            entertainments.AddEntertainment(new Anime("Kimetsu no Yaiba", GenreType.ACTION, Convert.ToDateTime("6/04/2019"), "ufotable", EntertainmentStatusType.COMPLETED, "Demon Slayer", Convert.ToDateTime("28/09/2019"), null, null, 26, 23));
            entertainments.AddEntertainment(new Manga("One Piece", GenreType.ACTION, Convert.ToDateTime("22/06/1997"), "Eiichiro Oda", EntertainmentStatusType.AIRING, null, null, null, null, 120, 6000));
            entertainments.AddEntertainment(new Anime("Kaguya-sama wa Kokurasetai: Tensai-tachi no Renai Zunousen", GenreType.COMEDY, Convert.ToDateTime("12/01/2019"), "A-1 Picture", EntertainmentStatusType.COMPLETED, "Kaguya-sama: Love is War", Convert.ToDateTime("30/03/2019"), null, null, 12, 25, null, (Anime)entertainments.GetEntertainment("Kaguya-sama wa Kokurasetai?: Tensai-tachi no Renai Zunousen")));
            entertainments.AddEntertainment(new Anime("Kaguya-sama wa Kokurasetai?: Tensai-tachi no Renai Zunousen", GenreType.COMEDY, Convert.ToDateTime("11/04/2020"), "A-1 Picture", EntertainmentStatusType.COMPLETED, "Kaguya-sama: Love is War Season 2", Convert.ToDateTime("27/06/2020"), null, null, 12, 25, (Anime)entertainments.GetEntertainment("Kaguya-sama wa Kokurasetai: Tensai-tachi no Renai Zunousen"), null));
            entertainments.AddEntertainment(new Manga("Oyasumi Punpun", GenreType.DRAMA, Convert.ToDateTime("15/03/2007"), "Inio Asano", EntertainmentStatusType.COMPLETED, "Goodnight Punpun", Convert.ToDateTime("2/11/2013"), null, null, 13, 147));

            Application.Run(new index(users, entertainments));
        }
    }
}
