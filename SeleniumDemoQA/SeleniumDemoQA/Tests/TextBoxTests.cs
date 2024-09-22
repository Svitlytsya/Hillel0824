using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Tests
{
    public class TextBoxTests: BaseClass
    {
        [Test, Description("Enter valid data in input fields, press the submit button and verify the output in the aftersubmit text area")]
        public void FillAndSubmitTextBoxTests()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            FillInput(By.Id("userName"), "Dog Pulya");
            FillInput(By.Id("userEmail"), "pulyadog@gmail.com");
            FillInput(By.CssSelector("#currentAddress.form-control"), "Varash city, Budivelnikiv street, building 3, apartment 333");
            FillInput(By.CssSelector("#permanentAddress.form-control"), "Varash city, Budivelnikiv street, building 3, apartment 333");


            ClickElement(By.Id("submit"));

            var FullNameOutput = GetElementBy(By.Id("name"));
            var EmailOutput = GetElementBy(By.Id("email"));
            var CurrentAddressOutput = GetElementBy(By.CssSelector("#output #currentAddress.mb-1"));
            var PermanentAddressOutput = GetElementBy(By.CssSelector("#output #permanentAddress.mb-1"));

            Assert.That(FullNameOutput.Text, Is.EqualTo("Name:Dog Pulya"));
            Assert.That(EmailOutput.Text, Is.EqualTo("Email:pulyadog@gmail.com"));
            Assert.That(CurrentAddressOutput.Text, Is.EqualTo("Current Address :Varash city, Budivelnikiv street, building 3, apartment 333"));
            Assert.That(PermanentAddressOutput.Text, Is.EqualTo("Permananet Address :Varash city, Budivelnikiv street, building 3, apartment 333"));



        }

    }
}
