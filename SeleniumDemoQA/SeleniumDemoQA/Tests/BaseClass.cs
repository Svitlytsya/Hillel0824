using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemoQA.Tests
{
    public class BaseClass
    {
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _js = (IJavaScriptExecutor)_driver;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }


        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        public void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public IWebElement GetElementBy(By selector)
        {
            return _driver.FindElement(selector);
        }

        public void FillInput(By selector, string value)
        {
            var firstNameInput = _driver.FindElement(selector);
            ScrollTo(firstNameInput);
            firstNameInput.SendKeys(value);
        }

        public void ClickElement(By selector)
        {
            var element = GetElementBy(selector);
            ScrollTo(element);
            element.Click();
        }

        public void SelectByText(By selector, string text)
        {
            var selectMonth = new SelectElement(_driver.FindElement(selector));
            selectMonth.SelectByText(text);
        }
        public string GetBorderColor(By selector)
        {
            var element = GetElementBy(selector);
            ScrollTo(element);
            return element.GetCssValue("border-color");
        }



    }


}
