using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds = 0)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
      
        }

        public static void NavigateTo(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void ScrollTo(this IWebDriver driver, IWebElement element)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        public static IWebElement GetElementBy(this IWebDriver driver, By selector)
        {
            return driver.FindElement(selector);
        }

        public static void ClickElement(this IWebDriver driver, By selector)
        {
            var element = driver.GetElementBy(selector);
            driver.ScrollTo(element);
            element.Click();
        }

        public static void FillInput(this IWebDriver driver, By selector, string value)
        {
            var firstNameInput = driver.GetElementBy(selector);
            driver.ScrollTo(firstNameInput);
            firstNameInput.SendKeys(value);
        }

        public static void SelectByText(this IWebDriver driver, By selector, string text)
        {
            var selectMonth = new SelectElement(driver.FindElement(selector));
            selectMonth.SelectByText(text);
        }

        public static void WaitForElementVisible(this IWebDriver driver, By by, int sec = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            wait.Until(d => d.FindElement(by).Displayed);
        }

        public static void WaitForElementInvisible(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => !d.FindElement(by).Displayed);
        }

        public static void WaitAndClickElement(this IWebDriver driver, By selector)
        {
            var timeStart = DateTime.Now;
            driver.WaitForElementVisible(selector);
            var timeEnd = DateTime.Now;
            Console.WriteLine(timeEnd - timeStart);

            IWebElement element = driver.FindElement(selector);
            driver.ScrollTo(element);
            element.Click();
        }

        public static void WaitForElementEnabled(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => d.FindElement(by).Displayed && d.FindElement(by).Enabled);
        }

        public static void ClickOnTableActionElement(this IWebDriver driver, By selector)
        {
            var element = driver.GetElementBy(selector);
            driver.ScrollTo(element);

            // Перевірка на видимість і доступність елемента
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => element.Displayed && element.Enabled);

            try
            {
                element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                // Виконати клік через JavaScript, якщо звичайний клік не працює
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
            }
        }


    }



}
