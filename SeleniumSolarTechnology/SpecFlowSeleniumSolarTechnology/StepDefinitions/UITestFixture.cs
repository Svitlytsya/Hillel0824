using OpenQA.Selenium;
using SpecFlowSeleniumSolarTechnology.Pages;


namespace SpecFlowSeleniumSolarTechnology.StepDefinitions
{
    public class UITestFixture
    {
        public IWebDriver _driver;

        public HomePage homePage;
        public CartPage cartPage;
        public CatalogPage catalogPage;

        //public ScenarioContext scenarioContext;
        public UITestFixture(ScenarioContext scenarioContext)
        {
            //scenarioContext = scenarioContext;
            _driver = scenarioContext["WebDriver"] as IWebDriver;

            homePage = new HomePage(_driver);
            cartPage = new CartPage(_driver);
            catalogPage = new CatalogPage(_driver);
        }
    }
}
