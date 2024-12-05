using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSeleniumDemoQA.Pages
{
    internal class TextBoxPage : BasePage    
    {
        public TextBoxPage(IWebDriver driver) : base(driver)
        {
        }

        By fullNameBy = By.Id("userName");
        By emailBy = By.Id("userEmail");
        By currentAddressBy = By.Id("currentAddress");
        By permanentAddressBy = By.Id("permanentAddress");
        By submitButtonBy = By.Id("submit");
        By nameOutputBy = By.Id("name");
        By emailOutputBy = By.Id("email");
        By currentOutputAddressBy = By.CssSelector("#output  #currentAddress");
        By permanentOutputAddressBy = By.CssSelector("#output  #permanentAddress");

        public void FillFullName(string fullName)
        {
            FillInput(fullNameBy, fullName);
        }

        public void FillEmail(string email)
        {
            FillInput(emailBy, email);
        }

        public void FillCurrentAddress(string currentAddress)
        {
            FillInput(currentAddressBy, currentAddress);
        }

        public void FillPermanentAddress(string permanentAddress)
        {
            FillInput(permanentAddressBy, permanentAddress);
        }
        public void SubmitForm()
        {
            ClickElement(submitButtonBy);
        }

        public string GetOutputName()
        {
            return FindElement(nameOutputBy).Text;
        }

        public string GetOutputEmail()
        {
            return FindElement(emailOutputBy).Text;
        }

        public string GetOutputCurrentAddress()
        {
            return FindElement(currentOutputAddressBy).Text;
        }

        public string GetOutputPermanentAddress()
        {
            return FindElement(permanentOutputAddressBy).Text;
        }

    }
}
