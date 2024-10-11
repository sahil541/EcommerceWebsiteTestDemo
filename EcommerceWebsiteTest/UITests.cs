using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace EcommerceWebsiteTest
{
    public class UITests : IDisposable
    {
        private readonly IWebDriver _driver;

        public UITests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Fact]
        public void OpenWebsiteAndCheckTitle()
        {
            _driver.Navigate().GoToUrl("https://www.snitch.co.in/");

            string title = _driver.Title;
            Assert.Equal("Discover Your Style – SNITCH", title);
        }

        [Fact]
        public void CheckElementIsVisible()
        {
            _driver.Navigate().GoToUrl("https://www.snitch.co.in/");

            IWebElement exampleLink = _driver.FindElement(By.CssSelector(".site-header__logo"));
            Assert.True(exampleLink.Displayed);
        }

        [Fact]
        public void ClickOnLinkAndCheckNewUrl()
        {
            _driver.Navigate().GoToUrl("https://www.snitch.co.in/");

            IWebElement exampleLink = _driver.FindElement(By.CssSelector(".site-nav__link.site-nav__link--icon.small--hide"));
            exampleLink.Click();

            string currentUrl = _driver.Url;
            Assert.Contains("account/login", currentUrl);
        }

        public void Dispose()
        {
            _driver.Quit();
        }

    }
}