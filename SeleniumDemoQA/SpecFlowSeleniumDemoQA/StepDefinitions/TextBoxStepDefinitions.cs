using NUnit.Framework;
using SpecFlowSeleniumDemoQA.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSeleniumDemoQA.StepDefinitions
{
    [Binding]
    public class TextBoxStepDefinitions : BaseClass
    {
        [Given(@"Open Text Box page")]
        public void GivenOpenTextBoxPage()
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.NavigateTo("https://demoqa.com/text-box");
        }

        [When(@"Fill Full Name '([^']*)'")]
        public void WhenFillFullName(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.FillFullName("Dog Pulya");
        }

        [When(@"Fill Email '([^']*)'")]
        public void WhenFillEmail(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.FillEmail("pulyadog@gmail.com");
        }

        [When(@"Fill Current Address '([^']*)'")]
        public void WhenFillCurrentAddress(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.FillCurrentAddress("Varash city, Budivelnikiv street, building 3, apartment 333");
        }

        [When(@"Fill Permanent Address '([^']*)'")]
        public void WhenFillPermanentAddress(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.FillPermanentAddress("03549,Kyiv city, Zhylyanska street, building 1, apartment 111");
        }

        [When(@"Submit Form")]
        public void WhenSubmitForm()
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.SubmitForm();
        }

        [Then(@"Output Name should be '([^']*)'")]
        public void ThenOutputNameShouldBe(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            Assert.That(textBoxPage.GetOutputName(), Is.EqualTo("Name:Dog Pulya"));
        }
    }
}
