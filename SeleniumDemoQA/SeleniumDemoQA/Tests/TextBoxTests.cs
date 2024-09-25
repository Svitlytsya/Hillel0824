using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class TextBoxTests: BaseClass
    {
        [Test, Description("Enter valid data in input fields, press the submit button and verify the output in the aftersubmit text area")]
        public void FillAndSubmitTextBoxTests()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            var formPage = new FormPage(_driver);

            formPage.FillFullName("Dog Pulya");
            formPage.FillUserEmail("pulyadog@gmail.com");
            formPage.FillAddress("Varash city, Budivelnikiv street, building 3, apartment 333");
            formPage.FillPermanentAddress("03549,Kyiv city, Zhylyanska street, building 1, apartment 111");


            formPage.SubmitButton();

            Assert.That(formPage.GetOutputFullName(), Is.EqualTo("Name:Dog Pulya"));
            Assert.That(formPage.GetOutputUserEmail(), Is.EqualTo("Email:pulyadog@gmail.com"));
            Assert.That(formPage.GetOutputAddress(), Is.EqualTo("Current Address :Varash city, Budivelnikiv street, building 3, apartment 333"));
            Assert.That(formPage.GetOutputPermanentAddress(), Is.EqualTo("Permananet Address :03549,Kyiv city, Zhylyanska street, building 1, apartment 111"));



        }

    }
}
