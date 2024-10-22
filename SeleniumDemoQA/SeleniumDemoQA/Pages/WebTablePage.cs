using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class WebTablePage
    {
        private IWebDriver _driver;

        public WebTablePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private string pageUrl = "https://demoqa.com/webtables";
        private By firstNameInput = By.CssSelector("[placeholder ='First Name']");
        private By lastNameInput = By.CssSelector("[placeholder ='Last Name']");
        private By emailInput = By.CssSelector("[placeholder ='name@example.com']");
        private By ageInput = By.CssSelector("[placeholder ='Age']");
        private By salaryInput = By.CssSelector("[placeholder ='Salary']");
        private By departmentInput = By.CssSelector("[placeholder ='Department']");
        private By submitBtn = By.CssSelector("#submit");
        private By addBtn = By.CssSelector("#addNewRecordButton");
        private By tableRows = By.CssSelector(".rt-tbody .rt-tr-group");

        public void Open()
        {
            _driver.NavigateTo(pageUrl);
        }

        public void AddButton()
        {
            _driver.ClickElement(addBtn);
        }

        public void FillFirstNameInput(string firstName)
        {
            _driver.FillInput(firstNameInput, firstName);
        }

        public void FillLastNameInput(string lastName)
        {
            _driver.FillInput(lastNameInput, lastName);
        }

        public void FillEmailInput(string email)
        {
            _driver.FillInput(emailInput, email);
        }

        public void FillAgeInput(string age)
        {
            _driver.FillInput(ageInput, age);
        }

        public void FillSalaryInput(string salary)
        {
            _driver.FillInput(salaryInput, salary);
        }

        public void FillDepartmentInput(string department)
        {
            _driver.FillInput(departmentInput, department);
        }

        public void SubmitButton()
        {
            _driver.ClickElement(submitBtn);
        }

        public int GetDataRowsCount()
        {
            var rows = _driver.FindElements(tableRows);
            return rows.Count(row => !string.IsNullOrWhiteSpace(row.Text));
        }
            

        public string GetRowText(int rowIndex)
        {
            var row = _driver.FindElements(tableRows)[rowIndex];
            return row.Text;
        }


        public void DeleteRowsByFirstName(string firstName)
        {
            By deleteRowBtn = By.XPath($"//*[@class='rt-tbody']//*[@class='rt-tr-group']//*[contains(@class,'rt-tr') and *[@class='rt-td' and text()='{firstName}']]//span[@title='Delete']");
            _driver.ClickOnTableActionElement(deleteRowBtn);

        }

        public bool IsRowByFirstNameDisplayed(string firstName)
        {
            try
            {
                By rowWithFirstName = By.XPath($"//div[contains(@class, 'rt-td') and text()='{firstName}']");
                return _driver.FindElement(rowWithFirstName).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;

            }


        }
    }

}
