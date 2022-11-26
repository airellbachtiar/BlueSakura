using Blue_Sakura_Logic.EnumCollection;
using Blue_Sakura_Logic.PersonalEntertainmentCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blue_Sakura_Unit_Test.PersonalEntertainmentCollectionTests
{
    [TestClass]
    public class PersonalEntertainmentTests
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

        PersonalEntertainment personalEntertainment;

        public PersonalEntertainmentTests()
        {
            int entertainmentID = 1;

            personalEntertainment = new PersonalEntertainment(entertainmentID);
        }

        [TestMethod]
        public void GenerateEntertainmentIDValueOfPersonalEntertainment_ReturnsEntertainmentID()
        {
            int expected = 1;
            int actual = personalEntertainment.EntertainmentID;

            RunTestAreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void GenerateStatusOfPersonalEntertainment_ReturnsStatus()
        {
            PersonalStatusType expected = PersonalStatusType.PLAN;
            PersonalStatusType actual = personalEntertainment.Status;

            RunTestAreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void GenerateProgressOfPersonalEntertainment_ReturnsProgress()
        {
            int expected = 1;
            int actual = personalEntertainment.Progress;

            RunTestAreEqual(expected.ToString(), actual.ToString());
        }

        private void RunTestAreEqual(string expected, string actual)
        {
            TestContext.WriteLine("Result: " + actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
