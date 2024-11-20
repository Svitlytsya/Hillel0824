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
    internal class ShopCartPage
    {
        private readonly IPage _page;

        public ShopCartPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToContinueShopping()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Continue Shopping" }).ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }




        //public async Task UpdateQuantity()
        //{
        //    await _page.GetByRole(AriaRole.Button, new() { Name = "" }).Nth(1).ClickAsync();
        //    await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        //    await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        //}


        public async Task EditProductQuantityinCart(string name, int quantity)
        {
            //await _page.Locator("#content").GetByRole(AriaRole.Table).GetByRole(AriaRole.Row).Filter(new() { HasText = name }).Locator("input[name^='quantity']").FillAsync(quantity.ToString());
            await _page.Locator("#content").GetByRole(AriaRole.Table).GetByRole(AriaRole.Row).Filter(new() { HasText = name }).Locator("input[name='quantity']").FillAsync(quantity.ToString());
            await _page.GetByRole(AriaRole.Button, new() { Name = "" }).Nth(1).ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public ILocator GetAddedProductLokator(string productName)
        {
            return _page.Locator("#content").GetByRole(AriaRole.Table).GetByRole(AriaRole.Row).Filter(new() { HasText = productName });

        }


     }
}
