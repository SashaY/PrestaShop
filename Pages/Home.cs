using OpenQA.Selenium;
using SeleniumFramework.Util;

namespace SeleniumFramework.Pages
{
    class Home
    {
        private IWebDriver driver = null;
        private Util.Util util = null;

        private By homePagePrimaryLinkXPath = By.XPath("//div[@id='header-menu']//a[contains(@class,'prestashop-link primary-link')]");
        private By resourcesMenuXpath = By.XPath("//div[@id='header-menu']//span[normalize-space()='Resources']");
        private By featureMenuXpath = By.XPath("//div[@id='header-menu']//a[text()='Features']");

        public Home(IWebDriver d)
        {
            driver = d;
            util = new Util.Util(d);
        }

        public bool IsHomePageLoaded()
            => util.IsElementVisible(homePagePrimaryLinkXPath);

        public bool ClickResourcesMenu()
            => util.ClickElement(resourcesMenuXpath);

        public bool HoverResourcesMenu()
            => util.HoverElement(resourcesMenuXpath);

        public bool ClickFeatureMenu()
            => util.ClickElement(featureMenuXpath);

        public void OpenHome()
        {
            driver.Navigate().GoToUrl("https://www.prestashop.com/en?ab=1");
            driver.Manage().Window.FullScreen();
            util.CaptureScreenshot();
        }
    }
}
