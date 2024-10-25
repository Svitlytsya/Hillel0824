using Atata;
using NUnit.Framework;
using System;

namespace AtataDemoQA
{
    public sealed class ButtonsTests : UITestFixture
    {
        [Test]
        public void ClickTest()
        {
            Go.To<ButtonsPage>()
                .PageTitle.Should.Contain("DEMOQA")
                .ClickMe.Click()
                .ClickMeResultText.Should.Be("You have done a dynamic click");
        }

        [Test]
        public void DoubleClickTest()
        {
            Go.To<ButtonsPage>()
                .DoubleClickButton.DoubleClick()
                .DoubleClickResultText.Should.Be("You have done a double click");
        }

        [Test]
        public void RightClickTest()
        {
            Go.To<ButtonsPage>()
                .RightClickButton.RightClick()
                .RightClickResultText.Should.Be("You have done a right click");
        }
    
    }


}
