using OpenQA.Selenium;
using SeleniumFramework.Util;

namespace SeleniumFramework.Pages
{
    class GettingStarted
    {
        private IWebDriver driver = null;
        private Util.Util util = null;

        private By pageHeader = By.XPath("//h1[contains(text(),'All PrestaShop') and contains(text(),'features')]");
        private By backToTop = By.XPath("//a[@class='back-to-top-a']");
        private By legalLink = By.XPath("//ul[contains(@class,'indexed-sidebar')]//a[text()='Legal']");

        public GettingStarted(IWebDriver d)
        {
            driver = d;
            util = new Util.Util(d);
        }

        public bool isFeaturePageLoaded()
            => util.IsElementVisible(pageHeader);

        public bool clickLegalLink()
            => util.ClickElement(legalLink);

        public bool clickBackToTop()
            => util.ClickElement(backToTop);
    }
}
