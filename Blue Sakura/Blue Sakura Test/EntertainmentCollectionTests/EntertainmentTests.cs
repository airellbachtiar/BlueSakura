using Blue_Sakura_Logic.EntertainmentCollection;
using Blue_Sakura_Logic.EnumCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Blue_Sakura_Unit_Test.EntertainmentCollectionTests
{
    [TestClass]
    public class EntertainmentTests
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

        public EntertainmentTests()
        {
            string title = "Title";
            GenreType mainGenre = GenreType.ACTION;
            DateTime startDate = DateTime.Parse("27/10/2020 00:00:00") ;
            DateTime endDate = DateTime.Parse("28/11/2020 00:00:00");

            Entertainment entertainment = new Entertainment(title, mainGenre, startDate);
            entertainment.EndDate = endDate;

            string title2 = "AnotherTitle";
            GenreType mainGenre2 = GenreType.COMEDY;
            DateTime startDate2 = DateTime.Now;

            Entertainment entertainment2 = new Entertainment(title2, mainGenre2, startDate2);

            entertainments.Add(entertainment);
            entertainments.Add(entertainment2);
        }

        [TestMethod]
        public void GenerateDefaultValueInEntertainment_WithoutID_ReturnsTrue()
        {
            string title = "Title";
            GenreType mainGenre = GenreType.ACTION;
            DateTime startDate = DateTime.Now;

            Entertainment entertainment = new Entertainment(title, mainGenre, startDate);

            Assert.AreEqual(entertainment.Title, title);
            Assert.AreEqual(entertainment.MainGenre, mainGenre);
            Assert.AreEqual(entertainment.StartDate, startDate);
            Assert.AreEqual(entertainment.Status, EntertainmentStatusType.COMING_SOON);
            Assert.AreEqual(entertainment.AlternateTitle, null);
            Assert.AreEqual(entertainment.EndDate, null);
            Assert.AreEqual(entertainment.Synopsis, null);
            Assert.AreEqual(entertainment.Description, null);
            Assert.AreEqual(entertainment.Picture, "default.png");
            Assert.AreEqual(entertainment.Genre, null);
        }

        [TestMethod]
        public void GenerateTitleInEntertainment_ReturnsTitle()
        {
            string expected = "Title";
            string actual = entertainments[0].Title;

            RunTestAreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void GenerateDifferentIDInEntertainment_ReturnsFalse()
        {
            int expected = 1;
            int actual = entertainments[1].Id;

            TestContext.WriteLine("Result: " + actual);
            Assert.IsFalse(actual < expected);
        }

        [TestMethod]
        public void GetMainGenreFromEntertainment_ReturnsEnumWithLowerCase()
        {
            string expected = "Action";
            string actual = entertainments[0].GetMainGenre();

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStatusFromEntertainment_ReturnsEnumWithLowerCase()
        {

            string expected = "Coming Soon";
            string actual = entertainments[0].GetStatus();

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStartDateFromEntertainment_ReturnsStartDate()
        {
            string expected = "27/10/2020";
            string actual = entertainments[0].GetStartDate;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetEndDateFromEntertainment_ReturnsEndDate()
        {
            string expected = "28/11/2020";
            string actual = entertainments[0].GetEndDate;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTypeFromEntertainment_ReturnsNull()
        {
            string expected = null;
            string actual = entertainments[0].Type();

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateTitleInEntertainment_ReturnsDefaultpng()
        {
            string expected = "default.png";
            string actual = entertainments[0].Picture;

            RunTestAreEqual(expected.ToString(), actual.ToString());
        }

        private void RunTestAreEqual(string expected, string actual)
        {
            TestContext.WriteLine("Result: " + actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
