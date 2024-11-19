using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task Open()
        {
            await _page.GotoAsync("https://ecommerce-playground.lambdatest.io");
        }

        public async Task OpenCategory(string name)
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Shop by Category" }).ClickAsync();
            await _page.GetByRole(AriaRole.Link, new() { Name = name }).ClickAsync();
            //await page.WaitForTimeoutAsync(3000);
            //await page.Locator(".product-thumb-top").First.WaitForAsync();
            //await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }
    
        public async Task SearchProductAndSelectFirstInDropDown(string name)
        {
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Search For Products" }).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Search For Products" }).FillAsync(name);
            //await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await _page.Locator("li a").Filter(new() { HasText = "HP LP3065" }).First.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
           

        }

        public async Task SearchProductBySearchButton(string name)
        {
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Search For Products" }).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Search For Products" }).FillAsync(name);
            await _page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }




    }
}
