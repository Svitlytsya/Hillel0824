using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public void FillLastName(string lastName)
        {
            FillInput(By.Id("lastName"), lastName);
        }

        public void FillEmail(string email)
        {
            FillInput(By.Id("userEmail"), email);
        }

        public void FillMobileNumber(string mobileNumber)
        {
            FillInput(By.Id("userNumber"), mobileNumber);
        }

        public void FillSubject(string subject)
        {
            FillInput(By.Id("subjectsInput"), subject);
            GetElementBy(By.Id("subjectsInput")).SendKeys(Keys.Enter);

        }

        public void FillCurrentAddress(string currentAddress)
        {
            FillInput(By.Id("currentAddress"), currentAddress);
        }

        //public void SelectGender(string gender)
        //{
        //    switch (gender)
        //    {
        //        case "Male":
        //        _driver.FindElement(By.CssSelector("label[for='gender-radio-1']")).Click();
        //        break;
        //        case "Female":
        //        _driver.FindElement(By.CssSelector("label[for='gender-radio-2']")).Click();
        //        break;
        //        case "Other":
        //        _driver.FindElement(By.CssSelector("label[for='gender-radio-2']")).Click();
        //        break;
        //        default:
        //        throw new ArgumentException($"Unknown gender: {gender}");

        //    }

        //}

        public void SelectGender(string gender)
        {
            By genderSelector;

            switch (gender.ToLower())
            {
                case "male":
                    genderSelector = By.XPath("//label[text()='Male']");
                    break;
                case "female":
                    genderSelector = By.XPath("//label[text()='Female']");
                    break;
                case "other":
                    genderSelector = By.XPath("//label[text()='Other']");
                    break;
                default:
                    throw new ArgumentException($"Unknown gender: {gender}");
            }

            ClickElement(genderSelector);
        }

        public void SelectDateOfBirth(string day, string month, string year)
        {
            ClickElement(By.Id("dateOfBirthInput"));
            var monthDropdown = new SelectElement(GetElementBy(By.ClassName("react-datepicker__month-select")));
            monthDropdown.SelectByText(month);
            var yearDropdown = new SelectElement(GetElementBy(By.ClassName("react-datepicker__year-select")));
            yearDropdown.SelectByText(year);
            //var dayElement = GetElementBy(By.XPath($"//div[contains(@class, 'react-datepicker__day') and text()='{day}']"));
            //dayElement.Click();
            By dayPickerBy = By.CssSelector($".react-datepicker__day--0{day}:not(.react-datepicker__day--outside-month)");
            ClickElement(dayPickerBy);

        }

        public void CheckHobby(string hobby)
        {
            switch (hobby)
            {
                case "Sports":
                    _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']")).Click();
                    break;
                case "Reading":
                    _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-2']")).Click();
                    break;
                case "Music":
                    _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-3']")).Click();
                    break;
                default:
                    throw new ArgumentException($"Unknown hobby: {hobby}");

            }

        }

        public void SelectState(string state)
        {
            By stateDropdownBy = By.Id("state");
            ClickElement(stateDropdownBy);
            ClickElement(By.XPath($"//div[text()='{state}']"));
        }

        public void SelectCity(string city)
        {
            By cityDropdownBy = By.Id("city");
            ClickElement(cityDropdownBy);
            ClickElement(By.XPath($"//div[text()='{city}']"));

        }
   
        public void SubmitButton()
        {
            ClickElement(By.Id("submit"));


        }

        public string GetElementBorderColor(By element)
        {
            ScrollTo(_driver.FindElement(element));
            return _driver.FindElement(element).GetCssValue("border-color");

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


    }

}
