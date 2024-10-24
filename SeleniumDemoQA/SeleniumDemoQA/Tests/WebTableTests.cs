using SeleniumDemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Tests
{
    public class WebTableTests: BaseClass
    {
        [Test]
        public void VerifyAddNewRowTable()
        {
            var webTablePage = new WebTablePage(_driver);
            webTablePage.Open();

            int initialRowCount = webTablePage.GetDataRowsCount();

            webTablePage.AddButton();
            webTablePage.FillFirstNameInput("Elchin");
            webTablePage.FillLastNameInput("Sangu");
            webTablePage.FillEmailInput("elchin@ask.com");
            webTablePage.FillAgeInput("41");
            webTablePage.FillSalaryInput("50000");
            webTablePage.FillDepartmentInput("Finance");
            webTablePage.SubmitButton();

            int rowsCountAfter = webTablePage.GetDataRowsCount();
            Assert.That(rowsCountAfter, Is.EqualTo(initialRowCount + 1), "The row count has not incresed in the web table");

            string addedRowText = webTablePage.GetRowText(3);
            Assert.That(addedRowText, Does.Contain("Elchin"));
            Assert.That(addedRowText, Does.Contain("Sangu"));
            Assert.That(addedRowText, Does.Contain("elchin@ask.com"));
            Assert.That(addedRowText, Does.Contain("41"));
            Assert.That(addedRowText, Does.Contain("50000"));
            Assert.That(addedRowText, Does.Contain("Finance"));

        }

        [Test]
        [TestCase("Cierra")]
        [TestCase("Alden")]
        [TestCase("Kierra")]
        public void RemoveRecordFromTable(string firstName)
        {
            var webTablePage = new WebTablePage(_driver);
            webTablePage.Open();

            int initialRowCount = webTablePage.GetDataRowsCount();

            webTablePage.DeleteRowsByFirstName(firstName);

            int rowsCountAfter = webTablePage.GetDataRowsCount();
            Assert.That(rowsCountAfter, Is.EqualTo(initialRowCount - 1));
            
            Assert.That(webTablePage.IsRowByFirstNameDisplayed(firstName), Is.False);

        }

    }
}
