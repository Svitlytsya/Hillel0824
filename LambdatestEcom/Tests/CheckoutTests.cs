using DecoratorDesignPatternTests.Models;
using LambdatestEcom.Pages;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : UITestFixture
    {
        [Test]
        public async Task CheckoutAsNewUser()
        {
            // Arrange
            DateTime now = DateTime.Now;
            string randomString = now.ToString("yyyyMMddHHmmss");
            var email = $"John.Doe{randomString}@example.com";

            var userDetails = new UserDetails
            {
                FirstName = "John",
                LastName = "Doe",
                Email = email,
                Telephone = "1234567890",
                Password = "password123",
                ConfirmPassword = "password123",
            };

            var billingAddress = new BillingAddress
            {
                Company = "Acme Corp",
                Address1 = "123 Main St",
                Address2 = "Apt 4",
                City = "Metropolis",
                PostCode = "12345",
                Country = "United States",
                Region = "Arizona"
            };

            var homePage = new HomePage(page);
            var catalogPage = new CatalogPage(page);
            var checkoutPage = new CheckoutPage(page);

            // Act
            await homePage.Open();
            await homePage.OpenCategory("Laptops & Notebooks");

            await catalogPage.FilterAvailability("In stock");
            await catalogPage.AddProductToCart(5);
            await catalogPage.GoToCheckout();

            await checkoutPage.FillUserDetails(userDetails);
            await checkoutPage.FillBillingAddress(billingAddress);
            await checkoutPage.AcceptPolicies();
            await checkoutPage.ConfirmOrder();
            await checkoutPage.Continue();

            // Assert
            StringAssert.EndsWith("?route=common/home", page.Url);
        }

    }
}
