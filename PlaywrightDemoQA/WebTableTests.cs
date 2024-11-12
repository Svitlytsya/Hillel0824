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

    [Test]
    public async Task EditRow()
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
            .GetByTitle("Edit").ClickAsync();
        await page.GetByPlaceholder("Last Name").FillAsync("Canter");
        await page.GetByPlaceholder("Salary").FillAsync("13200");
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("Canter");
        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("13200");

    }

    [Test]
    public async Task AddAndVerifynewRow()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/webtables");

        await page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
        await page.GetByPlaceholder("First Name").FillAsync("Elchin");
        await page.GetByPlaceholder("Last Name").FillAsync("Sangu");
        await page.GetByPlaceholder("name@example.com").FillAsync("elchinsangu@ask.com");
        await page.GetByPlaceholder("Age").FillAsync("42");
        await page.GetByPlaceholder("Salary").FillAsync("35000");
        await page.GetByPlaceholder("Department").FillAsync("Finance");
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

        var newRow = page.Locator(".rt-tr-group")
            .Filter(new() { HasText = "Elchin" })
            .Filter(new() { HasText = "Sangu" })
            .Filter(new() { HasText = "elchinsangu@ask.com" })
            .Filter(new() { HasText = "42" })
            .Filter(new() { HasText = "35000" })
            .Filter(new() { HasText = "Finance" });
        await Assertions.Expect(newRow).ToBeVisibleAsync();

    }

}
