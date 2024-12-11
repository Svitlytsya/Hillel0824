using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SpecFlowSeleniumSolarTechnology.Pages;
using OpenQA.Selenium;


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
