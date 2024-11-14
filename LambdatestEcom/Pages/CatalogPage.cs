using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class CatalogPage
    {
        private readonly IPage _page;

        public CatalogPage(IPage page)
        {
            _page = page;
        }

        public async Task FilterAvailability(string filterName)
        {
            await _page.Locator("#container .mz-filter-group.stock_status").GetByText(filterName).ClickAsync();
            await _page.WaitForRequestAsync("**/*&mz_fss*");
            //await _page.WaitForTimeoutAsync(3000);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public async Task AddProductToCart(int productIndex)
        {
            await _page.Locator(".product-thumb-top").Nth(productIndex).HoverAsync();
            await _page.Locator(".product-thumb-top").Nth(productIndex).GetByRole(AriaRole.Button).Filter(new() { HasText = "Add to Cart" }).ClickAsync();
            //await _page.Locator(".product-thumb-top").Nth(productIndex).GetByRole(AriaRole.Button).First.ClickAsync();
        }
        
        public async Task GoToCheckout()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Checkout" }).ClickAsync();
        }

    }
}
