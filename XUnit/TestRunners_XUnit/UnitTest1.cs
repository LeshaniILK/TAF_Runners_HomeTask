using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

namespace TestRunners_XUnit
{
    public class UnitTest1 : IClassFixture<XunitSetupClass>, IDisposable
    {
        IWebDriver driver;
        private readonly ITestOutputHelper _testOutputHelper;

        public IWebElement Username => driver.FindElement(By.Name("user-name"));
        public IWebElement Password => driver.FindElement(By.Name("password"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//*[@id='login-button']"));


        public UnitTest1(ITestOutputHelper testOutputHelper, XunitSetupClass XunitSetupClass)
        {
            _testOutputHelper = testOutputHelper;
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";
            _testOutputHelper.WriteLine("Xunit test Test Precondition output");
        }

        [Fact]
        public void SuccessLogin()
        {
            Username.SendKeys("standard_user");
            Password.SendKeys("secret_sauce");
            LoginBtn.Click();

            Assert.Equal("https://www.saucedemo.com/inventory.html", driver.Url);
            _testOutputHelper.WriteLine("Successfully Login");
        }

        [Fact(Skip = "Checking the skip attribute")]
        public void Test_Ignore()
        {
            _testOutputHelper.WriteLine("Xunit test Method output - Ignore Test");
        }

        [Fact]
        public void Test_Fail()
        {
            driver.Url = "https://www.saucedemo.com";
            Username.SendKeys("standard_user");
            Password.SendKeys("scrt_sauce");
            LoginBtn.Click();

            Assert.Equal("https://www.saucedemo.com/inventory.html", driver.Url);
            _testOutputHelper.WriteLine("Login Failed");
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("Xunit test Test Postcondition output");

            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }

            int i = 0;
        }

    }

    public class XunitSetupClass
    {
        public XunitSetupClass()
        {
            int i = 0;
        }

    }
}