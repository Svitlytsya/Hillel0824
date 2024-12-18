using LambdatestEcom.Pages;
using System;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Steps
{
    [Binding]
    public class ExistingUserTestsStepDefinitions : UITestFixture
    {
        public ExistingUserTestsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) 
        {
        }
        
        [Given(@"open home page")]
        public async Task GivenOpenHomePage()
        {
            var homePage = new HomePage(page);
            await homePage.Open();
        }

        [Given(@"open My account")]
        public async Task GivenOpenMyAccount()
        {
            var homePage = new HomePage(page);
            await homePage.OpenMyAccount();
        }

        [When(@"open Order History")]
        public async Task WhenOpenOrderHistory()
        {
            var myAccountPage = new MyAccountPage(page);
            await myAccountPage.OpenOrderHistory();
        }

        [Then(@"there are some Orders")]
        public async Task ThenThereAreSomeOrders()
        {
            var myAccountPage = new MyAccountPage(page);
            var orderCountBefore = await myAccountPage.GetOrderCount();
            Assert.That(orderCountBefore, Is.GreaterThan(1));
        }

    }
}

