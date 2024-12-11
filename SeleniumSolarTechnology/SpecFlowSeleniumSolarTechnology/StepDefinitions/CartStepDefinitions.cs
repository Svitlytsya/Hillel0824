using NUnit.Framework;
using SpecFlowSeleniumSolarTechnology.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSeleniumSolarTechnology.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions : UITestFixture
    {
        public CartStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
           
        }

        [Given(@"Open Cable And Switching link")]
        public void GivenOpenCableAndSwitchingLink()
        {
            homePage.OpenCableAndSwitching();
        }

        [When(@"Add product item to cart\((.*)\)")]
        public void WhenAddProductItemToCart(int p0)
        {
            catalogPage.AddProductItemToCart(1);

        }

        [When(@"Make order")]
        public void WhenMakeOrder()
        {
            cartPage.MakeOrder();
        }

        [When(@"Remove product item from cart\((.*)\)")]
        public void WhenRemoveProductItemFromCart(int p0)
        {
            cartPage.RemoveProductItemFromCart(0);
        }

        [Then(@"There must be a return to the Home page")]
        public void ThenThereMustBeAReturnToTheHomePage()
        {
            Assert.That(homePage.IsOnHomePage(), Is.True);
        }
    }
}
