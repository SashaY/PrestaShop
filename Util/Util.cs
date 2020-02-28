using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumFramework.Util
{
    class Util
    {
        private IWebDriver driver = null;

        public Util(IWebDriver d)
        {
            driver = d;
        }

        public void CaptureScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile($"C:\\JenkinsProjects\\Screenshots\\Step{GetTimestamp(DateTime.Now)}.jpeg", ScreenshotImageFormat.Jpeg);
            Console.WriteLine($"Screenshot captured in file C:\\JenkinsProjects\\Screenshots\\Step{GetTimestamp(DateTime.Now)}.jpeg");
        }

        public static string GetTimestamp(DateTime value)
            => value.ToString("yyyyMMddHHmmssffff");

        public IWebElement WaitForElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        public bool ClickElement(By locator)
        {
            bool returnValue = false;

            try
            {
                WaitForElementVisible(locator).Click();
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Element {locator} not found on page {driver.Title}");
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown error {e} occurred on page {driver.Title}");
                returnValue = false;
            }

            return returnValue;
        }

        public bool HoverElement(By locator)
        {
            bool returnValue = false;

            try
            {
                IWebElement element = driver.FindElement(locator);
                Actions action = new Actions(driver);
                action.MoveToElement(element).Perform();
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Element {locator} not found on page {driver.Title}");
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown error {e} occurred on page {driver.Title}");
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsElementVisible(By locator)
        {
            bool returnValue = false;

            try
            {
                returnValue = WaitForElementVisible(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Element {locator} not found on page {driver.Title}");
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown error {e} occurred on page {driver.Title}");
                returnValue = false;
            }

            return returnValue;
        }
    }
}
