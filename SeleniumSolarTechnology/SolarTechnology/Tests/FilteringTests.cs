using SolarTechnology.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarTechnology.Tests
{
    public class FilteringTests: UITestFixture
    {
        [Test]
        public void VerifyFilterByBrand()
        {
            var catalogPage = new CatalogPage(_driver);
            var homePage = new HomePage(_driver);

            homePage.Open();
            homePage.OpenSolarPanels();
            var countProductsBefore = catalogPage.CountProductItems();
                catalogPage.OpenFilters();
                catalogPage.CheckBrand("JA Solar");
            var countProductsAfter = catalogPage.CountProductItems();

            Assert.That(countProductsAfter, Is.LessThan(countProductsBefore), "The count of product items is not less after the filtering");
        }

    }


}
