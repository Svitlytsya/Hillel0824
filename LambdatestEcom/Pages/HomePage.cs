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
            //await _page.WaitForTimeoutAsync(3000);
            //await _page.Locator("#entry_217822").GetByText("HP LP3065").First.ClickAsync();
            //_page.Locator("#entry_217822").Filter(new() { Has = _page.GetByRole(AriaRole.Directory, new() { Name = "HP LP3065", Exact = true }) }).First.ClickAsync(); 
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
             _page.Locator("#entry_217822 li").Filter(new() { HasText = "HP LP3065"}).First.ClickAsync();

            // Чекаємо на появу хоча б одного елемента з випадаючого меню
            //var dropdownItemLocator = _page.Locator(".dropdown-menu.autocomplete li");
            //await dropdownItemLocator.First.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            // Знаходимо перший елемент, який містить назву продукту, і натискаємо на нього
            //var productItem = dropdownItemLocator.Filter(new() { HasText = name }).First;
            //await productItem.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            //await _page.WaitForTimeoutAsync(1000);
            //await productItem.ClickAsync();

            //await _page.Locator(".dropdown-menu.autocomplete").WaitForAsync();
            //await _page.Locator("#entry_217822").GetByText("HP LP3065").First.WaitForAsync();
            //await _page.Locator(".dropdown-menu.autocomplete li").First.ClickAsync();
            //await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            //var dropdown = _page.Locator("#entry_217822");
            //await dropdown.First.WaitForAsync();
            //await dropdown.Locator("li", new() { HasText = "HP LP3065" }).First.ClickAsync();

            

        }


    }
}
