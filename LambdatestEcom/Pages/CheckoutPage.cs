using DecoratorDesignPatternTests.Models;
using Microsoft.Playwright;
using System.Diagnostics.Metrics;

namespace LambdatestEcom.Pages
{
    public class CheckoutPage
    {
        private readonly IPage _page;

        public CheckoutPage(IPage page)
        {
            _page = page;
        }

        public async Task FillUserDetails(UserDetails userDetails)
        {
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name*" }).FillAsync(userDetails.FirstName);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name" }).FillAsync(userDetails.LastName);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "E-Mail" }).FillAsync(userDetails.Email);
            await _page.GetByPlaceholder("Telephone").FillAsync(userDetails.Telephone);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password*" }).FillAsync(userDetails.Password);
            await _page.GetByPlaceholder("Password Confirm").FillAsync(userDetails.ConfirmPassword);
        }
        
        public async Task FillBillingAddress(BillingAddress billingAddress)
        {
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1" }).FillAsync(billingAddress.Address1);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 2" }).FillAsync(billingAddress.Address2);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "City" }).FillAsync(billingAddress.City);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Post Code" }).FillAsync(billingAddress.PostCode);

            await SelectOptionByText(_page.Locator("#input-payment-country"), billingAddress.Country);
            await SelectOptionByText(_page.Locator("#input-payment-zone"), billingAddress.Region);
        }

        private async Task SelectOptionByText(ILocator locator, string text)
        {
            var valueCode = await locator.Locator($"//option[text()='{text}']").GetAttributeAsync("value");
            await locator.SelectOptionAsync(new[] { valueCode });

        }

        public async Task FillUserInfo(string randomString)
        {
            var email = $"alex.conner{randomString}@jmail.com";
            await Console.Out.WriteLineAsync(email);

            await _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name*" }).FillAsync("Alex");
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name*" }).FillAsync("Conner");
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "E-Mail*" }).FillAsync(email);
            await _page.GetByPlaceholder("Telephone").FillAsync("123456789");
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password*" }).FillAsync("qweasd");
            await _page.GetByPlaceholder("Password Confirm").FillAsync("qweasd");
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1" }).FillAsync("My main address");
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "City*" }).FillAsync("Sumy");
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Post Code" }).FillAsync("40000");
            await _page.Locator("#input-payment-country").SelectOptionAsync(new[] { "220" });
            await _page.Locator("#input-payment-zone").SelectOptionAsync(new[] { "3499" });
        }

        public async Task AcceptPolicies()
        {
            await _page.GetByText("I have read and agree to the Privacy Policy").ClickAsync();
            await _page.GetByText("I have read and agree to the Terms & Conditions").ClickAsync();
        }

        internal async Task UseExistingAddress()
        {
            await _page.Locator("#payment-address").GetByText("I want to use an existing").ClickAsync();
        }

        public async Task AcceptPolicy()
        {
            await _page.GetByText("I have read and agree to the Privacy Policy").ClickAsync();
        }

        public async Task AcceptTermsAndConditions()
        {
            await _page.GetByText("I have read and agree to the Terms & Conditions").ClickAsync();
        }


        public async Task ConfirmOrder()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Continue" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Confirm Order" }).ClickAsync();
        }
                
        public async Task Continue()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Continue" }).ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

    }
}
