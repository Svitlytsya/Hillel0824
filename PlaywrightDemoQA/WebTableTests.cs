using Microsoft.Playwright;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class WebTablesTest
{
    IBrowserContext context;

    [SetUp]
    public async Task Setup()
    {

        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        context = await browser.NewContextAsync();

        await context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });


    }

    [TearDown]
    public async Task TearDown()
    {
        await context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }


    [Test]
    public async Task DeleteRow()
    {
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

    [Test]
    public async Task EditRow()
    {
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/webtables");
        await page.Locator(".rt-tr-group").Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) }).GetByTitle("Edit").ClickAsync();
        await page.GetByPlaceholder("Last Name").FillAsync("Doe");
        var salary = int.Parse(await page.GetByPlaceholder("Salary").InputValueAsync());
        await page.GetByPlaceholder("Salary").FillAsync($"{salary + salary * 0.1}");
        await page.GetByText("Submit").ClickAsync();
        await Assertions.Expect(page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) })
            .GetByRole(AriaRole.Gridcell, new() { Name = "Doe", Exact = true }))
            .ToBeVisibleAsync();
    }

    [Test]
    public async Task AddRow()
    {
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://demoqa.com/webtables");
        var buttonAdd = page.GetByText("Add").And(page.GetByRole(AriaRole.Button));
        await buttonAdd.ClickAsync();

        await page.GetByPlaceholder("First Name").FillAsync("John");
        await page.GetByPlaceholder("Last Name").FillAsync("Doe");
        await page.GetByPlaceholder("name@example.com").FillAsync("john@doe.doe");
        await page.GetByPlaceholder("Age").FillAsync("40");
        await page.GetByPlaceholder("Salary").FillAsync("4000");
        await page.GetByPlaceholder("Department").FillAsync("QA");
        await page.GetByText("Submit").ClickAsync();

        var addedRow = await page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "John", Exact = true }) }).AllAsync();


        var columnHeaders = await page.Locator(".rt-thead").GetByRole(AriaRole.Columnheader).AllTextContentsAsync();


        var addedRowCells = page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "John", Exact = true }) })
            .GetByRole(AriaRole.Gridcell);

        await Assertions.Expect(addedRowCells.Nth(GetColumnIndex("First Name", columnHeaders))).ToHaveTextAsync("John");
        await Assertions.Expect(addedRowCells.Nth(GetColumnIndex("Last Name", columnHeaders))).ToHaveTextAsync("Doe");
        await Assertions.Expect(addedRowCells.Nth(GetColumnIndex("Age", columnHeaders))).ToHaveTextAsync("40");
        await Assertions.Expect(addedRowCells.Nth(GetColumnIndex("Email", columnHeaders))).ToHaveTextAsync("john@doe.doe");



    }


    private int GetColumnIndex(string columnHeader, IReadOnlyList<string> columnHeaders)
    {
        return columnHeaders.ToList().IndexOf(columnHeader);
    }


    [Test]
    public async Task Solar()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://solartechnology.com.ua/shop");
        await page.GetByRole(AriaRole.Link, new() { Name = "Акумулятори" }).ClickAsync();
        await page.GetByText("Фільтр товарів").ClickAsync();
        await page.GetByText("BYD", new() { Exact = true }).ClickAsync();
        await page.GetByRole(AriaRole.Link, new() { Name = "BYD B-Box 10", Exact = true }).ClickAsync();

    }


}
