using Blue_Sakura_Logic.UserCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blue_Sakura_Unit_Test.UserCollectionTests
{
    [TestClass]
    public class UserAccessTests
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

        [TestMethod]
        public void ShouldLogin_ReturnsTrue()
        {
            string username = "hinata";
            string password = "a";

            User user = UserAccess.Login(username, password);

            TestContext.WriteLine("Logged User: " + user.Username);
            Assert.IsNotNull(user);
        }
    }
}
