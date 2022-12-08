using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestRunners_MSTest
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        public TestContext TestContext { get; set; }

        public IWebElement Username => driver.FindElement(By.Name("user-name"));
        public IWebElement Password => driver.FindElement(By.Name("password"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//*[@id='login-button']"));


        [ClassInitialize]
        public static void ClassPrecondition(TestContext testContext)
        {
            testContext.WriteLine("MS test Class Precondition output");
        }

        [TestInitialize]
        public void TestPrecondition()
        {
            TestContext.WriteLine("MS test Test Precondition output");

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";

        }

        [TestMethod]
        public void SuccessLogin()
        {
            Username.SendKeys("standard_user");
            Password.SendKeys("secret_sauce");
            LoginBtn.Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
            TestContext.WriteLine("Successfully Login");
        }

        [TestMethod]
        [Ignore("Checking the ignore attribute")]
        public void Test_Ignore()
        {
            TestContext.WriteLine("Ignoring Test");
        }

        [TestMethod]
        public void FailLogin()
        {
            driver.Url = "https://www.saucedemo.com";
            Username.SendKeys("standard_user");
            Password.SendKeys("scrt_sauce");
            LoginBtn.Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
            TestContext.WriteLine("Login Failed");
        }

        [TestCleanup]
        public void MSTestCleanup()
        {
            TestContext.WriteLine("MS test Test Postcondition output");
            driver.Dispose();
        }

        [ClassCleanup]
        public static void MSTestClassCleanup()
        {
            int i = 0;
        }

    }
}