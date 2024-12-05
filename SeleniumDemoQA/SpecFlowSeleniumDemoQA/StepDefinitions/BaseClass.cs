using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SpecFlowSeleniumDemoQA.StepDefinitions
{
    public abstract class BaseClass
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
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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
