using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class CheckBoxPage: BasePage
    {
        public CheckBoxPage(IWebDriver driver) : base(driver)
        {
        }

        //By homeFolderCheckbox = By.XPath("//label[@for='tree-node-home']/span[@class='rct-checkbox']");
        By homeFolderCheckboxLabel = By.XPath("//label[@for='tree-node-home']");
        By homeFolderToggleButton = By.XPath("//button[@title='Toggle']");

        public void ExpandHomeFolder()
        {
            var toggleButton = GetElementBy(homeFolderToggleButton);
            ScrollTo(toggleButton);
            toggleButton.Click();
        }

        public void CheckHomeCheckBox()
        {
            var homeCheckboxLabel = GetElementBy(homeFolderCheckboxLabel);
            ScrollTo(homeCheckboxLabel);
            homeCheckboxLabel.Click();
            
        }
        public bool IsHomeCheckBoxChecked()
        {
            var homeCheckboxInput = GetElementBy(By.Id("tree-node-home"));
            return homeCheckboxInput.Selected;
        }


    }
}
