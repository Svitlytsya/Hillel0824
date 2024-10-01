using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumDemoQA.Pages
{
    internal class ButtonPage: BasePage
    {
        Actions actions;
        By doubleClickButtonSelector = By.Id("doubleClickBtn");
        By doubleClickMessageSelector = By.Id("doubleClickMessage");
        By rightClickButtonSelector = By.Id("rightClickBtn");
        By rightClickMessageSelector = By.Id("rightClickMessage"); 
        By clickMeButtonSelector = By.XPath("//button[text()='Click Me']");
        By clickMeMessageSelector = By.Id("dynamicClickMessage");


        public ButtonPage(IWebDriver driver) : base(driver)
        {
            actions = new Actions(driver);
        }

        public void DoubleClickTheDoubleClickButton() 
        {
            var doubleClickButton = GetElementBy(doubleClickButtonSelector);
            actions.DoubleClick(doubleClickButton).Perform();
        } 
        public string GetDoubleClickButtonMessage() 
        {
            var doubleClickMessage = GetElementBy(doubleClickMessageSelector);
            return doubleClickMessage.Text;

        }   
        public bool IsDoubleClickButtonMessageDisplayed() 
        {
           var doubleClickMessage = GetElementBy(doubleClickMessageSelector);
           return doubleClickMessage.Displayed;
        } 
        public void RightClickTheRightClickButton() 
        {
            var rightClickButton = GetElementBy(rightClickButtonSelector);
            actions.ContextClick(rightClickButton).Perform();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(By.Id("rightClickMessage")).Displayed);

        } 
        
        public string GetRightClickButtonMessage() 
        {
            var rightClickMessage = GetElementBy(rightClickMessageSelector);
            return rightClickMessage.Text;

        }   
        
        public bool IsRightClickButtonMessageDisplayed() 
        {
           var rightClickMessage = GetElementBy(rightClickMessageSelector);
           return rightClickMessage.Displayed;
        }

        public void ClickTheClickMeButton()
        {
            var ClickMeButton = GetElementBy(clickMeButtonSelector);
            actions.Click(ClickMeButton).Perform();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(By.Id("dynamicClickMessage")).Displayed);

        }

        public string GetClickMeButtonMessage()
        {
            var ClickMeMessage = GetElementBy(clickMeMessageSelector);
            return ClickMeMessage.Text;

        }

        public bool IsClickMeButtonMessageDisplayed()
        {
            var ClickMeMessage = GetElementBy(clickMeMessageSelector);
            return ClickMeMessage.Displayed;
        }








    }



}
