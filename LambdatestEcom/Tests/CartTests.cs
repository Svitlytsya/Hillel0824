using LambdatestEcom.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorDesignPatternTests.Models;
using LambdatestEcom.Pages;
using Microsoft.Playwright;
using System.Xml.Linq;


namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    internal class CartTests : UITestFixture
    {
        [Test]
        public async Task SearchingProductAndShoppingCartTest()
        {
            // Arrange
            DateTime now = DateTime.Now;
            string randomString = now.ToString("yyyyMMddHHmmss");

            var homePage = new HomePage(page);
            var catalogPage = new CatalogPage(page);
            var productPage = new ProductPage(page);
            var shopCartPage = new ShopCartPage(page);
            var addedProductRow = page.Locator("#content")
               .GetByRole(AriaRole.Table)
               .GetByRole(AriaRole.Row)
               .Filter(new() { HasText = "HP LP3065" });
            var addedProductRow2 = page.Locator("#content")
               .GetByRole(AriaRole.Table)
               .GetByRole(AriaRole.Row)
               .Filter(new() { HasText = "iPod Classic" });

            // Act
            await homePage.Open();
            await homePage.SearchProductAndSelectFirstInDropDown("HP LP3065");
            await productPage.IncreaseQuantityOfProduct(3);
            await productPage.AddProductToCart();
            await productPage.GoToShoppingCart();

            await Assertions.Expect(addedProductRow).ToContainTextAsync("HP LP3065");
            await Assertions.Expect(addedProductRow).ToContainTextAsync("3");
            await Assertions.Expect(addedProductRow).ToContainTextAsync("$366.00");

            await shopCartPage.GoToContinueShopping();
            await homePage. SearchProductBySearchButton("iPod Classic");
            await catalogPage.AddProductToCart(0);
            await productPage.GoToShoppingCart();

            await Assertions.Expect(addedProductRow).ToContainTextAsync("3");
            await Assertions.Expect(addedProductRow2).ToContainTextAsync("1");
            await Assertions.Expect(page.Locator("#content")).ToContainTextAsync("$488.00");

            await shopCartPage.EditProductQuantityinCart(2);
            await shopCartPage.UpdateQuantity();

            await Assertions.Expect(page.Locator("#content")).ToContainTextAsync("$610.00");
        }

    }
}



