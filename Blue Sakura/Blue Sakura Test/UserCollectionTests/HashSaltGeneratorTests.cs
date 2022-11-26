using Blue_Sakura_Logic.UserCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blue_Sakura_Unit_Test.UserCollectionTests
{
    [TestClass]
    public class HashSaltGeneratorTests
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
        public void ShouldGenerateHash_ReturnsTrue()
        {
            string salt = "TestSalt";
            string password = "TestPassword";

            string result = HashSaltGenerator.GetHash(password, salt);

            TestContext.WriteLine("Result: " + result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldGenerateRandomSalt_ReturnsTrue()
        {
            string result = HashSaltGenerator.GetSalt();

            TestContext.WriteLine("Result: "+ result);
            Assert.IsNotNull(result);
        }

    }
}
