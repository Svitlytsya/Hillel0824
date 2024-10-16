using SolarTechnology.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarTechnology.Tests
{
    public class CartTests : UITestFixture
    {
        [Test]
        public void VerifyAddToCartAndRemoveFromCartProductItem()
        {
            var catalogPage = new CatalogPage(_driver);
            var homePage = new HomePage(_driver);
            var cartPage = new CartPage(_driver);

            homePage.Open();
            homePage.OpenCableAndSwitching();
            catalogPage.AddProductItemToCart(1);
            cartPage.MakeOrder();
            cartPage.RemoveProductItemFromCart(0);
            Assert.That(homePage.IsOnHomePage(), Is.True);
        }

    }

}
