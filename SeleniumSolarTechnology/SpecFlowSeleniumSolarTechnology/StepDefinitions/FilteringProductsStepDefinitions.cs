using NUnit.Framework;
using SpecFlowSeleniumSolarTechnology.Pages;
using System;
using TechTalk.SpecFlow;

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
            var homePage = new HomePage(_driver);
            homePage.Open();
        }

        [Given(@"Open Solar Panels link")]
        public void GivenOpenSolarPanelsLink()
        {
            var homePage = new HomePage(_driver);
            homePage.OpenSolarPanels();
        }

        [When(@"Count product items before")]
        public void WhenCountProductItemsBefore()
        {
            var catalogPage = new CatalogPage(_driver);
            int countProductsBefore = catalogPage.CountProductItems();
            ScenarioContext.Current["CountBefore"] = countProductsBefore;
            Console.WriteLine($"Products before filtering: {countProductsBefore}");
        }

        [When(@"Open filter by brands")]
        public void WhenOpenFilterByBrands()
        {
            var catalogPage = new CatalogPage(_driver);
            catalogPage.OpenFilters();
        }

        [When(@"Check Brand '([^']*)'")]
        public void WhenCheckBrand(string p0)
        {
            var catalogPage = new CatalogPage(_driver);
            catalogPage.CheckBrand("JA Solar");
        }

        [When(@"Count product items after")]
        public void WhenCountProductItemsAfter()
        {
            var catalogPage = new CatalogPage(_driver);
            int countProductsAfter = catalogPage.CountProductItems();
            ScenarioContext.Current["CountAfter"] = countProductsAfter;
            Console.WriteLine($"Products after filtering: {countProductsAfter}");
        }

        [Then(@"The count product items should be less than before")]
        public void ThenTheCountProductItemsShouldBeLessThanBefore()
        {
            int countBefore = (int)ScenarioContext.Current["CountBefore"];
            int countAfter = (int)ScenarioContext.Current["CountAfter"];
            Assert.That(countAfter, Is.LessThan(countBefore),
                $"The count of product items is not less after the filtering. Expected less than {countBefore}, but was {countAfter}.");
        }
    }
}
