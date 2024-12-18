using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Steps
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly ScenarioContext _scenarioContext;
        public Hooks1(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("@login")]
        public async Task BeforeScenarioWithTag()
        {
            var page = _scenarioContext.Get<IPage>("page");
            var context = _scenarioContext.Get<IBrowserContext>("context");
            
            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login");
            if (await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).IsVisibleAsync())
            {
                await page.Locator("#input-email").FillAsync("alex.conner20241021231030@jmail.com");
                await page.Locator("#input-password").FillAsync("qweasd");
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

                await context.StorageStateAsync(new()
                {
                    Path = "../../../playwright/.auth/state.json"
                });
            }
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}