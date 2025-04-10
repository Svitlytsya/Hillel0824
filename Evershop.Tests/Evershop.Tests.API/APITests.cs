﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;

namespace Evershop.Tests.API
{
    [TestFixture]
    public class APITests
    {
        private RestClient _client;
        private string _sid;
        private CookieCollection _cookies;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient("http://localhost:3333");  // Base URL of the API
            var request = new RestRequest("admin/user/login", Method.Post);
            request.AddJsonBody(new { Email = "admin@admin.com", Password = "admin123" });

            var response = _client.Execute(request);
            _cookies = response.Cookies;

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            var jsonResponse = JObject.Parse(response.Content);
            Assert.IsNotNull(jsonResponse["data"]);  // Check if new ID was returned
            Assert.IsNotNull(jsonResponse["data"]["sid"]);  // Check if new ID was returned
            _sid = jsonResponse["data"]["sid"].ToString();
        }

        [Test]
        public async Task CreateProduct()
        {
            // Arrange
            var request = new RestRequest("http://localhost:3333/api/products", Method.Post);

            for (int i = 0; i < _cookies.Count; i++)
            {
                request.AddCookie(_cookies[i].Name, _cookies[i].Value, _cookies[i].Path, _cookies[i].Domain);
            }
            request.AddHeader("Authorization", $"Bearer {_sid}");

            var product = new Product()
            {
                Name = "Create product test 1",
                ProductId = "",
                Sku = "CPT-1",
                Price = "12.25",
                Weight = "0.28",
                CategoryId = "3",
                TaxClass = "",
                Description = "<p>Create product test 1 description</p>",
                UrlKey = "product1",
                MetaTitle = "",
                MetaKeywords = "",
                MetaDescription = "",
                Status = "1",
                Visibility = "1",
                ManageStock = "1",
                StockAvailability = "1",
                Qty = "1",
                GroupId = "1",
                Attributes =
                [
                    new Attribute() { AttributeCode = "color" },
                    new Attribute() { AttributeCode = "size" }
                ]
            };
            request.AddJsonBody(JsonConvert.SerializeObject(product));

            // Act
            var response = _client.Execute(request);

            // Assert
            var jsonResponse = JObject.Parse(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), jsonResponse.ToString());
            Assert.IsNotNull(jsonResponse["data"]);  // Check if new ID was returned
            Assert.IsNotNull(jsonResponse["data"]["product_description_id"]);  // Check if new ID was returned
            await Console.Out.WriteLineAsync(jsonResponse["data"]["product_description_id"].ToString());

            // Delete
            string uuid = jsonResponse["data"]["uuid"].ToString();
            request = new RestRequest($"http://localhost:3000/api/products/{uuid}", Method.Delete);
            for (int i = 0; i < _cookies.Count; i++)
            {
                request.AddCookie(_cookies[i].Name, _cookies[i].Value, _cookies[i].Path, _cookies[i].Domain);
            }
            request.AddHeader("Authorization", $"Bearer {_sid}");
            response = _client.Execute(request);

        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

    }
}
