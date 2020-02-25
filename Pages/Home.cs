using OpenQA.Selenium;
using SeleniumFramework.Util;

namespace SeleniumFramework.Pages
{
    class Home
    {
        private IWebDriver driver = null;
        private Util.Util util = null;

        private By homePagePrimaryLinkXPath = By.XPath("//div[@id='navbar-collapse-menu']//a[contains(@class,'prestashop-link primary-link')]");
        private By productMenuXpath = By.XPath("//div[@id='header-menu']//a[text()='Product']");
        private By featureMenuXpath = By.XPath("//div[@id='header-menu']//a[text()='Features']");

        public Home(IWebDriver d)
        {
            driver = d;
            util = new Util.Util(d);
        }

        public bool IsHomePageLoaded()
            => util.IsElementVisible(homePagePrimaryLinkXPath);

        public bool ClickProductMenu()
            => util.ClickElement(productMenuXpath);

        public bool HoverProductMenu()
            => util.HoverElement(productMenuXpath);

        public bool ClickFeatureMenu()
            => util.ClickElement(featureMenuXpath);

        public void OpenHome()
        {
            driver.Navigate().GoToUrl("https://www.prestashop.com/en");
            driver.Manage().Window.FullScreen();
            util.CaptureScreenshot();
    }
    }
}
