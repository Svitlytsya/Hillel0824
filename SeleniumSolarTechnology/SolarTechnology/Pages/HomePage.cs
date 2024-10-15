using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarTechnology.Pages
{
    internal class HomePage: BasePage
    {
        private string pageUrl = "https://solartechnology.com.ua/shop";
        private By solarPanelsLink = By.CssSelector(".list-inline [href='/shop/solar-panels']");
        private By cableSwitchingLink = By.CssSelector(".list-inline [href='/shop/solar-cable']");
        //private By cartIcon = By.CssSelector("cart-icon");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            NavigateTo(pageUrl);

            WaitForLoader();
        }


        public void OpenSolarPanels()
        {
            WaitAndClickElement(solarPanelsLink);

            WaitForLoader();
        }
        public void OpenCableAndSwitching()
        {
            WaitAndClickElement(cableSwitchingLink);

            WaitForLoader();
        }

        public bool IsOnHomePage()
        {
            return _driver.Url.Equals(pageUrl);
        }

    }

}

