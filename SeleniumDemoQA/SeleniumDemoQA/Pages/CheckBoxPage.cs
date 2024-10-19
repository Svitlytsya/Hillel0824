using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class CheckBoxPage
    {
        private IWebDriver _driver;

        public CheckBoxPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //By homeFolderCheckbox = By.XPath("//label[@for='tree-node-home']/span[@class='rct-checkbox']");
        By homeFolderCheckboxLabel = By.XPath("//label[@for='tree-node-home']");
        By homeFolderToggleButton = By.XPath("//button[@title='Toggle']");

        public void Open()
        {
            var pageUrl = "https://demoqa.com/checkbox";
            _driver.NavigateTo(pageUrl);

        }

        public void ExpandHomeFolder()
        {
            var toggleButton = _driver.GetElementBy(homeFolderToggleButton);
            _driver.ScrollTo(toggleButton);
            toggleButton.Click();
        }

        public void CheckHomeCheckBox()
        {
            var homeCheckboxLabel = _driver.GetElementBy(homeFolderCheckboxLabel);
            _driver.ScrollTo(homeCheckboxLabel);
            homeCheckboxLabel.Click();
            
        }
        public bool IsHomeCheckBoxChecked()
        {
            var homeCheckboxInput = _driver.GetElementBy(By.Id("tree-node-home"));
            return homeCheckboxInput.Selected;
        }


    }
}
