using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class TextBoxTests
{
    [Test]
    public async Task HasTitle()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/text-box");
        await page.GetByPlaceholder("Full Name").ClickAsync();
        await page.GetByPlaceholder("Full Name").FillAsync("Pulya Dog");
        await page.GetByPlaceholder("name@example.com").ClickAsync();
        await page.GetByPlaceholder("name@example.com").FillAsync("pulyadog@ask.com");
        await page.GetByPlaceholder("Current Address").ClickAsync();
        await page.GetByPlaceholder("Current Address").FillAsync("Varash city, Budivelnikiv street, building 3, apartment 333");
        await page.Locator("#permanentAddress").ClickAsync();
        await page.Locator("#permanentAddress").FillAsync("03549,Kyiv city, Zhylyanska street, building 1, apartment 111");
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Assertions.Expect(page.Locator("#name")).ToContainTextAsync("Name:Pulya Dog");
        await Assertions.Expect(page.Locator("#email")).ToContainTextAsync("Email:pulyadog@ask.com");
        await Assertions.Expect(page.Locator("#output")).ToContainTextAsync("Current Address :Varash city, Budivelnikiv street, building 3, apartment 333");
        await Assertions.Expect(page.Locator("#output")).ToContainTextAsync("Permananet Address :03549,Kyiv city, Zhylyanska street, building 1, apartment 111");

    }


}