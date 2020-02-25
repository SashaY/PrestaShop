using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumFramework.Pages;
using FluentAssertions;

namespace SeleniumFramework.Tests
{
    [TestFixture]
    class testClass
    {
        IWebDriver driver = null;
        GettingStarted gettingStarted = null;
        Home home = null;
        
        [OneTimeSetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            gettingStarted = new GettingStarted(driver);
            home = new Home(driver);
        }

        [Test]
        public void TestHomePage()
        {
            home.OpenHome();
            home.IsHomePageLoaded().Should().BeTrue();
            Console.WriteLine("App is launched successfully");
        }

        [Test]
        public void TestGoToFeaturePage()
        {
            home.OpenHome();
            home.HoverResourcesMenu();
            home.ClickFeatureMenu();
            gettingStarted.isFeaturePageLoaded().Should().BeTrue();
            Console.WriteLine("Clicked on Feature Menu");
        }

        [Test]
        public void TestFeaturePage()
        {
            home.OpenHome();
            home.HoverResourcesMenu();
            home.ClickFeatureMenu();
            gettingStarted.isFeaturePageLoaded().Should().BeTrue();
            gettingStarted.clickLegalLink();
            gettingStarted.clickBackToTop().Should().BeTrue();
            Console.WriteLine("Feature Page testing completed");
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
