using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace SeleniumDemoQA.Tests
{
    public class ButtonTests
    {
        private ChromeDriver _driver;

        [SetUp]
        public void Setup()
        {
          

            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://demoqa.com/buttons");
        }

        [Test]
        public void DoubleClickButtonTest()
        {
            var doubleClickButton = _driver.FindElement(By.Id("doubleClickBtn"));
            Actions actions = new Actions(_driver);
            actions.DoubleClick(doubleClickButton).Perform();

            var doubleClickMessage = _driver.FindElement(By.Id("doubleClickMessage"));
            Assert.IsTrue(doubleClickMessage.Displayed);
            Assert.AreEqual("You have done a double click", doubleClickMessage.Text);
        }

        [Test]
        public void RightClickButtonTest()
        {
            var rightClickButton = _driver.FindElement(By.Id("rightClickBtn"));
            Actions actions = new Actions(_driver);
            actions.ContextClick(rightClickButton).Perform();

            var rightClickMessage = _driver.FindElement(By.Id("rightClickMessage"));
            Assert.IsTrue(rightClickMessage.Displayed);
            Assert.AreEqual("You have done a right click", rightClickMessage.Text);
        }

        [Test]
        public void ClickMeButtonTest()
        {
            var clickMeButton = _driver.FindElement(By.XPath("//button[text()='Click Me']"));
            clickMeButton.Click();

            var dynamicClickMessage = _driver.FindElement(By.Id("dynamicClickMessage"));
            Assert.IsTrue(dynamicClickMessage.Displayed);
            Assert.AreEqual("You have done a dynamic click", dynamicClickMessage.Text);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}