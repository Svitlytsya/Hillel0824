using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using SeleniumDemoQA.Models;
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
        By confirmationModalElement = By.Id("example-modal-sizes-title-lg");

        private IWebDriver _driver;

        public FormPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            var pageUrl = "https://demoqa.com/automation-practice-form";
            _driver.NavigateTo(pageUrl);

        }

        public void FillFirstName(string firstName)
        {
            _driver.FillInput(By.Id("firstName"), firstName);
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
            _driver.FillInput(By.Id("lastName"), lastName);
        }

        public void FillEmail(string email)
        {
            _driver.FillInput(By.Id("userEmail"), email);
        }

        public void FillMobileNumber(string mobileNumber)
        {
            _driver.FillInput(By.Id("userNumber"), mobileNumber);
        }

        public void FillSubject(string subject)
        {
            _driver.FillInput(By.Id("subjectsInput"), subject);
            _driver.GetElementBy(By.Id("subjectsInput")).SendKeys(Keys.Enter);

        }

        public void FillCurrentAddress(string currentAddress)
        {
            _driver.FillInput(By.Id("currentAddress"), currentAddress);
        }

        //public void SelectGender(Gender gender)
        //{
        //    switch (gender)
        //    {
        //        case Gender.Male:
        //        _driver.FindElement(By.CssSelector("label[for='gender-radio-1']")).Click();
        //        break;
        //        case Gender.Female:
        //        _driver.FindElement(By.CssSelector("label[for='gender-radio-2']")).Click();
        //        break;
        //        case Gender.Other:
        //        _driver.FindElement(By.CssSelector("label[for='gender-radio-2']")).Click();
        //        break;
        //        default:
        //        throw new ArgumentException($"Unknown gender: {gender}");

        //    }

        //}

        public void SelectGender(Gender gender)
        {
            By genderSelector;

            switch (gender)
            {
                case Gender.Male:
                    genderSelector = By.XPath("//label[text()='Male']");
                    break;
                case Gender.Female:
                    genderSelector = By.XPath("//label[text()='Female']");
                    break;
                case Gender.Other:
                    genderSelector = By.XPath("//label[text()='Other']");
                    break;
                default:
                    throw new ArgumentException($"Unknown gender: {gender}");
            }

            _driver.ClickElement(genderSelector);
        }

        public void SelectDateOfBirth(string day, string month, string year)
        {
            _driver.ClickElement(By.Id("dateOfBirthInput"));
            _driver.SelectByText(By.ClassName("react-datepicker__month-select"), month);
            _driver.SelectByText(By.ClassName("react-datepicker__year-select"), year);
            By dayPickerBy = By.CssSelector($".react-datepicker__day--0{day}:not(.react-datepicker__day--outside-month)");
            _driver.ClickElement(dayPickerBy);

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
            _driver.ClickElement(stateDropdownBy);
            _driver.ClickElement(By.XPath($"//div[text()='{state}']"));
        }

        public void SelectCity(string city)
        {
            By cityDropdownBy = By.Id("city");
            _driver.ClickElement(cityDropdownBy);
            _driver.ClickElement(By.XPath($"//div[text()='{city}']"));

        }
   
        public void SubmitButton()
        {
            _driver.ClickElement(By.Id("submit"));

        }

        public string GetElementBorderColor(By element)
        {
            _driver.ScrollTo(_driver.FindElement(element));
            return _driver.FindElement(element).GetCssValue("border-color");

        }


    }

}
