using Microsoft.Playwright;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class WebTablesTest
{
    [Test]
    public async Task DeleteRow()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/webtables");
        await page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) })
            .GetByTitle("Delete").ClickAsync();
        await Assertions.Expect(page.GetByText("Alden")).Not.ToBeVisibleAsync();
    }
}