using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SpecFlowSeleniumSolarTechnology.StepDefinitions
{
    public class UITestFixture
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        [BeforeScenario]
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _js = (IJavaScriptExecutor)_driver;
        }

        [AfterScenario]
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
