using Microsoft.Playwright;

namespace LambdatestEcom
{
    public class UITestFixture2
    {
        public IPage page { get; private set; }
        private IBrowser browser;
        public IBrowserContext context;

        [SetUp]
        public async Task Setup()
        {
            var ciEnv = Environment.GetEnvironmentVariable("CI");

            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false //ciEnv == "true"
            });

            string subPath = "../../../playwright/.auth";
            string filePath = "../../../playwright/.auth/state.json";

            if (!Directory.Exists(subPath))
                Directory.CreateDirectory(subPath);


            if (!File.Exists(filePath))
                File.AppendAllText(filePath, "{}");


            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                },
                IgnoreHTTPSErrors = true,

                StorageStatePath = "../../../playwright/.auth/state.json"
            });

            await context.Tracing.StartAsync(new()
            {
                Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            page = await context.NewPageAsync();

            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login");
            if (await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).IsVisibleAsync())
            {
                await page.Locator("#input-email").FillAsync("elchinsangu@ask.com");
                await page.Locator("#input-password").FillAsync("1509");
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

                await context.StorageStateAsync(new()
                {
                    Path = "../../../playwright/.auth/state.json"
                });
            }

            page.SetDefaultTimeout(5000);
        }

        [TearDown]
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