using Atata;
using NUnit.Framework;
using System;

namespace AtataDemoQA
{
    public sealed class PeoplesTests : UITestFixture
    {
        [Test]
        public void DeleteAndVerifyRowWithAldenDeleted()
        {
            Go.To<WebTablesPage>().
                People.Should.BeVisible().
            People.Rows[row => row.FirstName.Content.Value.Equals("Alden")].DeleteButton.Click().
            People.Rows[row => row.FirstName.Content.Value.Equals("Alden")].Should.Not.BeVisible();
        }

        [Test]
        public void AddAndVerifyNewRowWithDatasEdded()
        {
            Go.To<WebTablesPage>().
                People.Should.BeVisible().
                Add.Should.BeEnabled().
                Add.Click().
                    AddPopup.FirstName.Set("Elchin").
                    AddPopup.LastName.Set("Sangu").
                    AddPopup.Email.Set("elchin@ask.com").
                    AddPopup.Age.Set("41").
                    AddPopup.Salary.Set("50000").
                    AddPopup.Department.Set("Finance").
                    AddPopup.Submit.Click().
                People.Rows.Count.Should.BeGreater(3).
                People.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].FirstName.Should.BeVisible().
                People.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].LastName.Should.Be("Sangu").
                People.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Age.Should.Be("41").
                People.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Email.Should.Be("elchin@ask.com").
                People.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Salary.Should.Be("30000").
                People.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Department.Should.Be("Finance");

        }
    }
}
