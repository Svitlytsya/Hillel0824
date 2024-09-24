using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class FormPage
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        By confirmationModalElement = By.Id("example-modal-sizes-title-lg");

        public FormPage(IWebDriver driver)
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;

        }

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
            var firstNameInput = GetElementBy(selector);
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

        public void FillFirstName(string firstName)
        {
            FillInput(By.Id("firstName"), firstName);
        }
        internal bool IsConfirmationModalDisplayed()
        {
            return _driver.FindElement(confirmationModalElement).Displayed;
        }
        internal string GetConfirmationModalText()
        {
            return _driver.FindElement(confirmationModalElement).Text;
        }

    }
}
