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

        public async Task ProductNameFromTableCell()
        {
          var productNameContent = _page.Locator("#content").GetByRole(AriaRole.Table).GetByRole(AriaRole.Row).GetByRole(AriaRole.Cell).Filter(new() { HasText = "HP LP3065" }).InnerTextAsync();

        }


        //public async Task<string> GetProductName()
        //{
        //    // Знайти назву продукту в рядку таблиці, де є назва "HP LP3065"
        //    var rowLocator = _page.Locator("#content table tbody tr")
        //        .Filter(new() { HasText = "HP LP3065" });

        //    // У рядку знайти текст у клітинці, яка містить назву продукту
        //    var productCell = rowLocator.Locator("td").First;

        //    return await productCell.InnerTextAsync();
        //}

        //_page.Locator("#content").GetByRole(AriaRole.Table).GetByRole(AriaRole.Row).Filter(new() { Has = _page.GetByRole(AriaRole.Cell, new() { Name = "HP LP3065", Exact = true }) });
    }
}
