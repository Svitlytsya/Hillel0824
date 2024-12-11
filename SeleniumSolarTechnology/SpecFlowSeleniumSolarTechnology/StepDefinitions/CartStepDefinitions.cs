using NUnit.Framework;

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

        [When(@"Add second product item from catalog to cart")]
        public void WhenAddProductItemToCart()
        {
            catalogPage.AddProductItemToCart(1);
        }

        [When(@"Make order")]
        public void WhenMakeOrder()
        {
            cartPage.MakeOrder();
        }

        [When(@"Remove first product item from cart")]
        public void WhenRemoveProductItemFromCart()
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
