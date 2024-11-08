using Atata;
using NUnit.Framework;
using System;

namespace AtataDemoQA
{
    public sealed class TextBoxTests : UITestFixture
    {
        [Test]
        public void FillInputsAndVerifyOutputsOfTextBox()
        {
            Go.To<TextBoxPage>().
                FullName.Set("Dog Pulya").
                Email.Set("pulyadog@ask.com").
                CurrentAddress.Set("Varash city, Budivelnikiv street, building 3, apartment 333").
                PermanentAddress.Set("03549,Kyiv city, Zhylyanska street, building 1, apartment 111").
            ScrollDown().
            Submit.Click().
                FullNameOutput.Should.Be("Name:Dog Pulya").
                EmailOutput.Should.Be("Email:pulyadog@ask.com").
                CurrentAddressOutput.Should.Be("Current Address :Varash city, Budivelnikiv street, building 10, apartment 123").
                PermanentAddressOutput.Should.Be("Permananet Address :03549,Kyiv city, Zhylyanska street, building 1, apartment 111");

        }
    }
}
