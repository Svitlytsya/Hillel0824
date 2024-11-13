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

        var salaryText = await page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) })
            //.Locator("rt-td").GetByRole(AriaRole.Gridcell, new() { Name = "12000" })
            .Locator(".rt-td").Nth(4)
            .InnerTextAsync();
        int currentSalary = int.Parse(salaryText);
        int newSalary = (int)(currentSalary * 1.1);

        await page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) })
            .GetByTitle("Edit").ClickAsync();
        await page.GetByPlaceholder("Last Name").FillAsync("Canter");
        await page.GetByPlaceholder("Salary").FillAsync(newSalary.ToString());
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("Canter");
        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync(newSalary.ToString());

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
            .Filter(new() { HasText = "Elchin" });
        await Assertions.Expect(newRow).ToContainTextAsync("Sangu");
        await Assertions.Expect(newRow).ToContainTextAsync("42");
        await Assertions.Expect(newRow).ToContainTextAsync("elchinsangu@ask.com");
        await Assertions.Expect(newRow).ToContainTextAsync("35000");
        await Assertions.Expect(newRow).ToContainTextAsync("Finance");

    }

}
