using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Hooks
{
    [Binding]
    public sealed class SpecFlowHooks
    {
        private readonly ScenarioContext _scenarioContext;
        public IPage page { get; private set; }
        private IBrowser browser;
        public IBrowserContext context;
        private bool _useState = true;

        public SpecFlowHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _useState = _scenarioContext.ScenarioInfo.Tags.Contains("login");
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
        public async Task Setup()
        {
            var ciEnv = Environment.GetEnvironmentVariable("CI");

            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false //ciEnv == "true"
            });

            if (_useState)
            {
                string subPath = "../../../playwright/.auth";
                string filePath = "../../../playwright/.auth/state.json";

                if (!Directory.Exists(subPath))
                    Directory.CreateDirectory(subPath);


                if (!File.Exists(filePath))
                    File.AppendAllText(filePath, "{}");
            }

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                },
                IgnoreHTTPSErrors = true,

                StorageStatePath = _useState ? "../../../playwright/.auth/state.json" : null,
            });

            await context.Tracing.StartAsync(new()
            {
                Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            page = await context.NewPageAsync();
            _scenarioContext["page"] = page;
            _scenarioContext["context"] = context;


            page.SetDefaultTimeout(5000);
        }

        [AfterScenario]
        public async Task Teardown()
        {
            await context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
            });

            await page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}