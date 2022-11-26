using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.EnumCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Blue_Sakura_Unit_Test.EntertainmentCollectionTests
{
    [TestClass]
    public class MangaTests
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

        Entertainment entertainment;

        public MangaTests()
        {
            string title = "Manga";
            GenreType mainGenre = GenreType.ACTION;
            DateTime startDate = DateTime.Parse("27/10/2020 00:00:00") ;
            string author = "Author";

            Manga manga = new Manga(title, mainGenre, startDate, author);
            entertainment = manga;
        }

        [TestMethod]
        public void GetAuthorFromManga_ReturnsString()
        {
            string expected = "Author";
            string actual = ((Manga)entertainment).Author;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetDefaultVolumeValueFromManga_ReturnsInt()
        {
            int expected = 0;
            int? actual = ((Manga)entertainment).Volumes;

            RunTestAreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void GetDefaultChapterValueFromManga_ReturnsInt()
        {
            int expected = 0;
            int? actual = ((Manga)entertainment).Chapters;

            RunTestAreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void GetVolumeValueFromManga_ReturnsInt()
        {
            int expected = 2;
            ((Manga)entertainment).Volumes = expected;
            int? actual = ((Manga)entertainment).Volumes;

            RunTestAreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void GetChapterValueFromManga_ReturnsInt()
        {
            int expected = 2;
            ((Manga)entertainment).Chapters = expected;
            int? actual = ((Manga)entertainment).Chapters;

            RunTestAreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void GetTypeFromEntertainment_ReturnsString()
        {
            string expected = "Manga";
            string actual = entertainment.Type();

            RunTestAreEqual(expected, actual);
        }

        private void RunTestAreEqual(string expected, string actual)
        {
            TestContext.WriteLine("Result: " + actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
