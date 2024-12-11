using NUnit.Framework;


namespace SpecFlowSeleniumSolarTechnology.StepDefinitions
{
    [Binding]
    public class FilteringProductsStepDefinitions : UITestFixture
    {
        public FilteringProductsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            Console.WriteLine("FilteringProductsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)");
        }

        [Given(@"Open Solartechnology Shop page")]
        public void GivenOpenSolartechnologyShopPage()
        {
            homePage.Open();
        }

        [Given(@"Open Solar Panels link")]
        public void GivenOpenSolarPanelsLink()
        {
            homePage.OpenSolarPanels();
        }

        [When(@"Count product items before")]
        public void WhenCountProductItemsBefore()
        {
            int countProductsBefore = catalogPage.CountProductItems();
            scenarioContext["CountBefore"] = countProductsBefore;
            Console.WriteLine($"Products before filtering: {countProductsBefore}");
        }

        [When(@"Open filter by brands")]
        public void WhenOpenFilterByBrands()
        {
            catalogPage.OpenFilters();
        }

        [When(@"Check Brand '([^']*)'")]
        public void WhenCheckBrand(string brandName)
        {
            catalogPage.CheckBrand(brandName);
        }

        [When(@"Count product items after")]
        public void WhenCountProductItemsAfter()
        {
            int countProductsAfter = catalogPage.CountProductItems();
            scenarioContext["CountAfter"] = countProductsAfter;
            Console.WriteLine($"Products after filtering: {countProductsAfter}");
        }

        [Then(@"The count product items should be less than before")]
        public void ThenTheCountProductItemsShouldBeLessThanBefore()
        {
            int countBefore = (int)scenarioContext["CountBefore"];
            int countAfter = (int)scenarioContext["CountAfter"];
            Assert.That(countAfter, Is.LessThan(countBefore),
                $"The count of product items is not less after the filtering. Expected less than {countBefore}, but was {countAfter}.");
        }
    }
}
