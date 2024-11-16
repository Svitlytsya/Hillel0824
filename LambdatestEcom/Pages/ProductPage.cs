using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorDesignPatternTests.Models;
using LambdatestEcom.Pages;
using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class ProductPage
    {
        private readonly IPage _page;

        public ProductPage(IPage page)
        {
            _page = page;
        }

        public async Task IncreaseQuantityOfProduct(int quantity)
        {

            await _page.GetByRole(AriaRole.Button, new() { Name = "Increase quantity" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Increase quantity" }).ClickAsync();
            //await _page.WaitForTimeoutAsync(2000);
            //await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            //await _page.GetByRole(AriaRole.Button).Filter(new() { HasText = "Increase quantity" }).ClickAsync();
            // await _page.GetByRole(AriaRole.Button).Filter(new() { HasText = "Increase quantity" }).ClickAsync();
            
        }
        public async Task AddProductToCart()
        {
            //await _page.WaitForTimeoutAsync(3000);
            //await _page.GetByRole(AriaRole.Button, new() { Name = "Add to Cart" }).ClickAsync();
            await _page.Locator("#entry_216842").GetByRole(AriaRole.Button, new() { Name = "Add to Cart", Exact = true }).ClickAsync();
          
         }

        public async Task GoToShoppingCart()
        {
             await _page.GetByRole(AriaRole.Link, new() { Name = "View Cart " }).ClickAsync();
        }






    }
}
