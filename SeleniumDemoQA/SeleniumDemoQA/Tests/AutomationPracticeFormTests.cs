using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V127.CSS;
using OpenQA.Selenium.Support.UI;
using SeleniumDemoQA.Models;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class AutomationPracticeFormTests: BaseClass
    {

        [Test]
        public void FillAndSubmitFormTest()
        {
            
            var formPage = new FormPage(_driver);

            //formPage.FillInput(By.Id("firstName"), "John");
            formPage.NavigateTo("https://demoqa.com/automation-practice-form");
            formPage.FillFirstName("John");
            formPage.FillLastName("Doe");
            formPage.FillEmail("johndoe@example.com");
            formPage.SelectGender(Gender.Male);
            formPage.FillMobileNumber ("1234567890");            
            formPage.SelectDateOfBirth("15", "May", "1990");
            formPage.FillSubject("Maths");
            formPage.CheckHobby("Music");
            formPage.FillCurrentAddress("123 Main Street, Anytown, USA");
            formPage.SelectState("NCR");
            formPage.SelectCity("Delhi");
            formPage.SubmitButton();

            // Validate the Form Submission (e.g., check for the confirmation modal)
            //var confirmationModal = formPage.GetElementBy(By.Id("example-modal-sizes-title-lg"));
            var isConfirmationModalDisplayed = formPage.IsConfirmationModalDisplayed();
            var confirmationModalText = formPage.GetConfirmationModalText();

            Assert.That(isConfirmationModalDisplayed);
            Assert.That(confirmationModalText, Is.EqualTo("Thanks for submitting the form"));
        }


        [Test]
        public void VerifyFormValidationTest()
        {
            string redBorderColor = "rgb(220, 53, 69)";
            By firstNameInputBy = By.Id("firstName");
            By lastNameInputBy = By.Id("lastName");
            By emailInputBy = By.Id("userEmail");
            By mobileNumberInputBy = By.Id("userNumber");


            
            var formPage = new FormPage(_driver);
            formPage.NavigateTo("https://demoqa.com/automation-practice-form");
            formPage.SubmitButton();
            Thread.Sleep(1000);

            Assert.Multiple(() =>
            {
                Assert.That(formPage.GetElementBorderColor(firstNameInputBy), Is.EqualTo(redBorderColor), "First Name validation failed.");
                Assert.That(formPage.GetElementBorderColor(lastNameInputBy), Is.EqualTo(redBorderColor), "Last Name validation failed.");
                //Assert.That(formPage.GetElementBorderColor(emailInputBy), Is.EqualTo(redBorderColor), "Email validation failed.");
                Assert.That(formPage.GetElementBorderColor(mobileNumberInputBy), Is.EqualTo(redBorderColor), "Mobile Number validation failed.");
            });
        
        }

        
    }
}