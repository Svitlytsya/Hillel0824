using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSeleniumSolarTechnology.Pages
{
    internal class CatalogPage : BasePage
    {
        private By filterButton = By.CssSelector(".filter-button");
        private By productItem = By.CssSelector(".product-block .prod-holder");
        private By addToCartBtn = By.CssSelector(".add-product-to-cart");
        
        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }

        public void OpenFilters()
        {
            WaitAndClickElement(filterButton);
        }

        public void CheckBrand(string brand)
        {
            var brandCheckbox = By.XPath($"//*[@id='checkbox-brand']/following-sibling::span[text()='{brand}']");
            WaitAndClickElement(brandCheckbox);

            WaitForLoader();
        }

        public int CountProductItems()
        {
            var productItems = _driver.FindElements(productItem);
            return productItems.Count();
        }

        public void AddProductItemToCart(int productIndex)
        {
            var productItems = _driver.FindElements(productItem);
            var product = productItems[productIndex];
            var addCartButton = product.FindElement(addToCartBtn);

            addCartButton.Click();

            //product.Click();
            //WaitForLoader();
            //var addCartButton = _driver.FindElements(addToCartBtn);
            //addCartButton[productIndex].Click();
            //WaitForLoader();

        }


    }
}

