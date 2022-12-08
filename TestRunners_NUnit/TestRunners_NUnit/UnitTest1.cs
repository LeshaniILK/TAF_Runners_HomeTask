using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestRunners_NUnit
{
    [TestFixture]
    public class Tests
    {
        static int testCounter;
        public IWebDriver driver;

        public IWebElement Username => driver.FindElement(By.Name("user-name"));
        public IWebElement Password => driver.FindElement(By.Name("password"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//*[@id='login-button']"));

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            TestContext.WriteLine("Nunit Class Precondition - Class Setup");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";
        }

        [SetUp]
        public void TestSetUp()
        {
            TestContext.WriteLine("Nunit Test Precondition - Test Setup");
            testCounter++;
            Console.WriteLine("Test started number {0}", testCounter);
        }

        [Test, Order(1)]
        public void SuccessLogin()
        {
            Username.SendKeys("standard_user");
            Password.SendKeys("secret_sauce");
            LoginBtn.Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
            TestContext.WriteLine("Successfully Login");
        }

        [Test, Order(2)]
        [Ignore("Checking the ignore attribute")]
        public void Test_Ignore()
        {
            TestContext.WriteLine("Ignoring test");
            Assert.Pass();
        }

        [Test, Order(3)]
        public void FailLogin()
        {
            driver.Url = "https://www.saucedemo.com";
            Username.SendKeys("standard_user");
            Password.SendKeys("scrt_sauce");
            LoginBtn.Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
            TestContext.WriteLine("Login Failed");
        }

        [TearDown]
        public void NUnitTearDown()
        {

            Console.WriteLine("Test Count : ", testCounter);
            TestContext.WriteLine("Nunit Test Postcondition - Test Tear Down");
        }

        [OneTimeTearDown]
        public void NUnitOneTimeTearDown()
        {
            TestContext.WriteLine("Nunit Class Postcondition - Class Tear Down");
            driver.Quit();
        }

    }
}