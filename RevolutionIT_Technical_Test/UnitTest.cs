using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace RevolutionIT_Technical_Test
{
    [TestClass]
    public class UnitTest
    {
        public IWebDriver Driver { get; set; }
        public WebPage Page { get; set; }


        [TestInitialize]
        public void SetupTest()
        {
            Driver = new FirefoxDriver();
            Page = new WebPage(Driver);
        }


        [TestCleanup]
        public void TeardownTest()
        {
            Driver.Quit();
        }

        [TestMethod]
        public void TestPages()
        {
            Page.Navigate();
            // Assert is used to check state of test after each load.
            Assert.IsTrue(Driver.Title.Equals("Welcome: Mercury Tours"));
            Page.Login("mercury", "mercury");
            Assert.IsTrue(Driver.Title.Equals("Find a Flight: Mercury Tours:"));
            Page.FindFlight();
            Assert.IsTrue(Driver.Title.Equals("Select a Flight: Mercury Tours"));
            Page.SelectFlight();
            Assert.IsTrue(Driver.Title.Equals("Book a Flight: Mercury Tours"));
            Page.BookFlight(new Person("Paras", "Sharma", "123456789123456"));
            Assert.IsTrue(Driver.Title.Equals("Book a Flight: Mercury Tours"));
        }
    }
}
