using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumDemoQA.Pages;
using System;


namespace SeleniumDemoQA.Tests
{
    public class ButtonTests: BaseClass
    {
        ButtonPage buttonPage;
        
        [SetUp]
        public void SetUp()
        {
            buttonPage = new ButtonPage(_driver);
            buttonPage.NavigateTo("https://demoqa.com/buttons");

        }
        
            [Test]
        public void DoubleClickButtonTest()
        {
            
            buttonPage.DoubleClickTheDoubleClickButton();
           
            Assert.That(buttonPage.IsDoubleClickButtonMessageDisplayed(), Is.True);
            Assert.That(buttonPage.GetDoubleClickButtonMessage(), Is.EqualTo("You have done a double click"));
        }

        [Test]
        public void RightClickButtonTest()
        {
       
            buttonPage.RightClickTheRightClickButton();

            Assert.That(buttonPage.IsRightClickButtonMessageDisplayed(), Is.True);
            Assert.That(buttonPage.GetRightClickButtonMessage(), Is.EqualTo("You have done a right click"));
        }

        [Test]
        public void ClickMeButtonTest()
        {
            //var clickMeButton = _driver.FindElement(By.XPath("//button[text()='Click Me']"));
            buttonPage.ClickTheClickMeButton();


            var dynamicClickMessage = _driver.FindElement(By.Id("dynamicClickMessage"));
            Assert.That(buttonPage.IsClickMeButtonMessageDisplayed(), Is.True);
            Assert.That(buttonPage.GetClickMeButtonMessage(), Is.EqualTo("You have done a dynamic click"));
        }

    
    }
}