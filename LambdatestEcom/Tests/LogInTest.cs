using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LambdatestEcom.Pages;
using Microsoft.Playwright;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    internal class LogInTest: UITestFixture
    {
        [Test]
        public async Task CheckStateIsLoaded()
        {
           var loginPage = new LoginPage(page);

            await loginPage.Open();
            
            //var multipart = context.APIRequest.CreateFormData();
            //multipart.Append("email", "elchinsangu@ask.com");
            //multipart.Append("password", "1509");

            //var response = await context.APIRequest.PostAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login",
            //               new() { Form = multipart });

            //Assert.That(response.Ok, "API login request was not successful");

            await loginPage.OpenAccount();

            var myAccountHeader = await loginPage.MyAccountHeaderIsVisible();
            Assert.That(myAccountHeader, Is.True, "User is not logged in successfully.");

         
        }
   
    }
}
