using OpenQA.Selenium;

namespace SpecFlowSeleniumSolarTechnology.Pages
{
    public class CartPage: BasePage
    {
        private By orderButton = By.XPath("//*[@class='buttons']//a[contains(@href, '/cart')]");
        private By removeItemIcon = By.CssSelector(".remove-from-cart>.material-icons");


        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void MakeOrder()
        {
            WaitForElementEnabled(orderButton);
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

