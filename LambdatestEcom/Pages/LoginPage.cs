using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task Open()
        {
            await _page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login");
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public async Task OpenAccount()
        {
            await _page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/account");
            
        }


        public async Task<bool> MyAccountHeaderIsVisible()
        {
            //.Locator("h2:has-text('My Account')")
            return await _page.Locator("//h2[text() = 'My Account']").IsVisibleAsync();

        }

           
    }
}
