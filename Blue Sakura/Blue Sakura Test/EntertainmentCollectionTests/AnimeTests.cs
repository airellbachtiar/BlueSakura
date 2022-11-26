using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.EnumCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Blue_Sakura_Unit_Test.EntertainmentCollectionTests
{
    [TestClass]
    public class AnimeTests
    {
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        List<Entertainment> entertainments = new List<Entertainment>();

        public AnimeTests()
        {
            string title = "Movie";
            GenreType mainGenre = GenreType.ACTION;
            DateTime startDate = DateTime.Parse("27/10/2020 00:00:00") ;
            string studio = "StudioA";
            int duration = 178;

            Anime anime = new Anime(title, mainGenre, startDate, studio);
            anime.Duration = duration;
            anime.Sequel = 2;

            string title2 = "Show";
            GenreType mainGenre2 = GenreType.COMEDY;
            DateTime startDate2 = DateTime.Now;
            string studio2 = "StudioB";
            int duration2 = 23;
            int nrOfEpisode2 = 3;

            Anime anime2 = new Anime(title2, mainGenre2, startDate2, studio2);
            anime2.Duration = duration2;
            anime2.NrOfEpisode = nrOfEpisode2;

            entertainments.Add(anime);
            entertainments.Add(anime2);
        }

        [TestMethod]
        public void GetStudioFromEntertainment_ReturnsStudio()
        {
            string expected = "StudioA";
            string actual = ((Anime)entertainments[0]).Studio;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetShowEpisodeFromEntertainment_ReturnsNumberOfEpisode()
        {
            string expected = "3";
            string actual = ((Anime)entertainments[1]).NrOfEpisode.ToString();

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPrequelFromEntertainment_Returns2()
        {
            string expected = "2";
            string actual = ((Anime)entertainments[0]).Sequel.ToString();

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPictureFromEntertainment_ReturnsDefaultpng()
        {
            string expected = "default.png";
            string actual = ((Anime)entertainments[0]).Picture;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMovieDurationFromEntertainment_ReturnsMovieDuration()
        {
            string expected = "2 hr. 58 min.";
            string actual = ((Anime)entertainments[0]).GetDuration;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetShowDurationFromEntertainment_ReturnsShoqDuration()
        {
            string expected = "23 min. per ep.";
            string actual = ((Anime)entertainments[1]).GetDuration;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTypeFromEntertainment_ReturnsAnime()
        {
            string expected = "Anime";
            string actual = entertainments[0].Type();

            RunTestAreEqual(expected, actual);
        }

        private void RunTestAreEqual(string expected, string actual)
        {
            TestContext.WriteLine("Result: " + actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
