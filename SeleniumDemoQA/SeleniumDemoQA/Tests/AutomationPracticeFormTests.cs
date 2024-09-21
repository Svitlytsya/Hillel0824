using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V127.CSS;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemoQA.Tests
{
    public class AutomationPracticeFormTests: BaseClass
    {

        [Test]
        public void FillAndSubmitFormTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            FillInput(By.Id("firstName"), "John");
            FillInput(By.Id("lastName"), "Doe");
            FillInput(By.Id("userEmail"), "johndoe@example.com");

            ClickElement(By.CssSelector("label[for='gender-radio-1']"));

            FillInput(By.Id("userNumber"), "1234567890");
            
            ClickElement(By.Id("dateOfBirthInput"));
            SelectByText(By.ClassName("react-datepicker__month-select"), "May");
            SelectByText(By.ClassName("react-datepicker__year-select"), "1990");
            ClickElement(By.CssSelector(".react-datepicker__day--015:not(.react-datepicker__day--outside-month)"));

            FillInput(By.Id("subjectsInput"), "Maths");
            GetElementBy(By.Id("subjectsInput")).SendKeys(Keys.Enter);

            ClickElement(By.CssSelector("label[for='hobbies-checkbox-1']"));
            FillInput(By.Id("currentAddress"), "123 Main Street, Anytown, USA");

            ClickElement(By.Id("state"));
            ClickElement(By.XPath("//div[text()='NCR']"));

            ClickElement(By.Id("city"));
            ClickElement(By.XPath("//div[text()='Delhi']"));

            ClickElement(By.Id("submit"));

            // Validate the Form Submission (e.g., check for the confirmation modal)
            var confirmationModal = GetElementBy(By.Id("example-modal-sizes-title-lg"));
           
            Assert.That(confirmationModal.Displayed);
            Assert.That(confirmationModal.Text, Is.EqualTo("Thanks for submitting the form") );
        }


        [Test]
        public void VerifyFormValidationTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            ClickElement(By.Id("submit"));

            string firstNameBorderColor = GetBorderColor(By.Id("firstName"));
            string lastNameBorderColor = GetBorderColor(By.Id("lastName"));
            string emailBorderColor = GetBorderColor(By.Id("userEmail"));
            string mobileNumberBorderColor = GetBorderColor(By.Id("userNumber"));
           

            // Check if the border color indicates an error (commonly red)
            string expectedErrorBorderColor = "rgb(220, 53, 69)"; 

            Assert.That(expectedErrorBorderColor, Is.EqualTo(firstNameBorderColor), "First Name validation failed.");
            Assert.That(expectedErrorBorderColor, Is.EqualTo(lastNameBorderColor), "Last Name validation failed.");
            //Assert.That(expectedErrorBorderColor, Is.EqualTo(emailBorderColor), "Email validation failed.");
            Assert.That(expectedErrorBorderColor, Is.EqualTo(mobileNumberBorderColor), "Mobile Number validation failed.");
        }

        
    }
}