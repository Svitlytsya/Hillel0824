using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSeleniumDemoQA.Pages
{
    internal class BasePage
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;
        }

        public void NavigateTo(string link)
        {
            _driver.Navigate().GoToUrl(link);
        }

        public void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            //_js.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }
        public IWebElement GetElementBy(By selector)
        {
            return _driver.FindElement(selector);
        }
        public string GetElementText(By selector)
        {
            var element = GetElementBy(selector);
            return element.Text;
        }
        protected bool IsElementDisplayed(By selector)
        {
            var element = GetElementBy(selector);
            return element.Displayed;
        }

        public void FillInput(By selector, string value)
        {
            IWebElement element = FindElement(selector);
            ScrollTo(element);
            element.SendKeys(value);
        }

        public void ClickElement(By selector)
        {
            IWebElement element = FindElement(selector);
            ScrollTo(element);
            element.Click();
        }

        public void WaitAndClickElement(By selector, int seconds = 3)
        {
            var timeStart = DateTime.Now;
            WaitForElementVisible(selector, seconds);
            var timeEnd = DateTime.Now;
            Console.WriteLine(timeEnd - timeStart);

            IWebElement element = FindElement(selector);
            ScrollTo(element);
            element.Click();
        }

        public void SelectDefinedElement(By selector, string value)
        {
            var elements = new SelectElement(FindElement(selector));
            elements.SelectByText(value);
        }

        public IWebElement FindElement(By by)
        {
            IWebElement element = _driver.FindElement(by);
            return element;
        }

        public void WaitForElementVisible(By by, int sec = 3)
        {
            var timeStart = DateTime.Now;
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(sec));
                wait.Until(d => d.FindElement(by).Displayed);
            }
            catch
            {
                var timeEnd = DateTime.Now;
                Console.WriteLine(timeEnd - timeStart);
                throw;
            }
        }

        public void WaitForElementInvisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(d => !d.FindElement(by).Displayed);
        }

        public void WaitForElementEnabled(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(d => d.FindElement(by).Displayed && d.FindElement(by).Enabled);
        }

    }
}
