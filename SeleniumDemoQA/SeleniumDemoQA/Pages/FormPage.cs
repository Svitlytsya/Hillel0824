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
    internal class FormPage: BasePage
    {
        By confirmationModalElement = By.Id("example-modal-sizes-title-lg");

        public FormPage(IWebDriver driver) : base(driver)
        {

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


    }

}
