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
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.Open();
            
            textBoxPage.FillFullName("Dog Pulya");
            textBoxPage.FillUserEmail("pulyadog@gmail.com");
            textBoxPage.FillAddress("Varash city, Budivelnikiv street, building 3, apartment 333");
            textBoxPage.FillPermanentAddress("03549,Kyiv city, Zhylyanska street, building 1, apartment 111");


            textBoxPage.SubmitButton();

            Assert.Multiple(() =>
            {
                Assert.That(textBoxPage.GetOutputFullName(), Is.EqualTo("Name:Dog Pulya"));
                Assert.That(textBoxPage.GetOutputUserEmail(), Is.EqualTo("Email:pulyadog@gmail.com"));
                Assert.That(textBoxPage.GetOutputAddress(), Is.EqualTo("Current Address :Varash city, Budivelnikiv street, building 3, apartment 333"));
                Assert.That(textBoxPage.GetOutputPermanentAddress(), Is.EqualTo("Permananet Address :03549,Kyiv city, Zhylyanska street, building 1, apartment 111"));
            });

        }

    }
}
