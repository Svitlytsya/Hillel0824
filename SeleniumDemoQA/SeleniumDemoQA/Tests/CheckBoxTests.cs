using SeleniumDemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Tests
{
    internal class CheckBoxTests: BaseClass
    {
        [Test]
        public void VerifyCheckBoxesCheckedAfterCheckAndExpandTheHome()
        {
            var checkBoxPage = new CheckBoxPage(_driver);
            checkBoxPage.NavigateTo("https://demoqa.com/checkbox");

            checkBoxPage.ExpandHomeFolder();

            checkBoxPage.CheckHomeCheckBox();

            Assert.That(checkBoxPage.IsHomeCheckBoxChecked(), Is.True);

        }

    }
}
