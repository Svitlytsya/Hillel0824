using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarTechnology.Pages
{
    internal class CartPage: BasePage
    {
        private By loader = By.Id("p_prldr");
        private By orderButton = By.CssSelector(".buttons [href='/cart']");
        private By removeItemIcon = By.CssSelector(".remove-from-cart>.material-icons");


        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void WaitForLoader()
        {
            WaitForElementVisible(loader);
            WaitForElementInvisible(loader);
        }


        public void MakeOrder()
        {
            ClickElement(orderButton);
            WaitForLoader();
        }

        public void RemoveProductItemFromCart(int productIndex)
        {
            var removeButtons = _driver.FindElements(removeItemIcon);
            removeButtons[productIndex].Click();
            WaitForLoader();
        }
          
    }

}

