using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class TextBoxPage: BasePage    
    {
        public TextBoxPage(IWebDriver driver) : base(driver)
        {

        }

        public void FillFullName(string fullName)
        {
            FillInput(By.Id("userName"), fullName);
        }

        public void FillUserEmail(string userEmail)
        {
            FillInput(By.Id("userEmail"), userEmail);
        }

        public void FillAddress(string currentAddress)
        {
            FillInput(By.CssSelector("#currentAddress.form-control"), currentAddress);
        }

        public void FillPermanentAddress(string permanentAddress)
        {
            FillInput(By.CssSelector("#permanentAddress.form-control"), permanentAddress);
        }

        public string GetOutputFullName()
        {
            return _driver.FindElement(By.Id("name")).Text;

        }

        public string GetOutputUserEmail()
        {
            return _driver.FindElement(By.Id("email")).Text;

        }

        public string GetOutputAddress()
        {
            return _driver.FindElement(By.CssSelector("#output #currentAddress.mb-1")).Text;

        }

        public string GetOutputPermanentAddress()
        {
            return _driver.FindElement(By.CssSelector("#output #permanentAddress.mb-1")).Text;

        }

        public void SubmitButton()
        {
            ClickElement(By.Id("submit"));

        }

    }
}
