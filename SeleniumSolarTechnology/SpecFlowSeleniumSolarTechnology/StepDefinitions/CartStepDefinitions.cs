using NUnit.Framework;
using SpecFlowSeleniumSolarTechnology.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSeleniumSolarTechnology.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions : UITestFixture
    {
        [Given(@"Open Cable And Switching link")]
        public void GivenOpenCableAndSwitchingLink()
        {
            var homePage = new HomePage(_driver);
            homePage.OpenCableAndSwitching();
        }

        [When(@"Add product item to cart\((.*)\)")]
        public void WhenAddProductItemToCart(int p0)
        {
            var catalogPage = new CatalogPage(_driver);
            catalogPage.AddProductItemToCart(1);

        }

        [When(@"Make order")]
        public void WhenMakeOrder()
        {
            var cartPage = new CartPage(_driver);
            cartPage.MakeOrder();
        }

        [When(@"Remove product item from cart\((.*)\)")]
        public void WhenRemoveProductItemFromCart(int p0)
        {
            var cartPage = new CartPage(_driver);
            cartPage.RemoveProductItemFromCart(0);
        }

        [Then(@"There must be a return to the Home page")]
        public void ThenThereMustBeAReturnToTheHomePage()
        {
            var homePage = new HomePage(_driver);
            Assert.That(homePage.IsOnHomePage(), Is.True);
        }
    }
}
