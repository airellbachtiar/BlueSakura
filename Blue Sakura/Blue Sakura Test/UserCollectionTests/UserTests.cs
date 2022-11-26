using Blue_Sakura_Logic.UserCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blue_Sakura_Unit_Test.UserCollectionTests
{
    [TestClass]
    public class UserTests
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

        User user;

        public UserTests()
        {
            string email = "TestEmail";
            string username = "TestUsername";
            string password = "password";
            string salt = "salt";

            user = new User(email, username, password, salt);
        }

        [TestMethod]
        public void GenerateFieldEmailValueInUser_ReturnsEmail()
        {
            string expected = "TestEmail";
            string actual = user.Email;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateFieldUsernameValueInUser_ReturnsUsername()
        {
            string expected = "TestUsername";
            string actual = user.Username;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateFieldPasswordValueInUser_ReturnsPassword()
        {
            string expected = "password";
            string actual = user.Password;

            RunTestAreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateFieldSaltValueInUser_ReturnsSalt()
        {
            string expected = "salt";
            string actual = user.Salt;

            RunTestAreEqual(expected, actual);
        }

        private void RunTestAreEqual(string expected, string actual)
        {
            TestContext.WriteLine("Result: " + actual);
            Assert.AreEqual(expected, actual);
        }
    }

}
