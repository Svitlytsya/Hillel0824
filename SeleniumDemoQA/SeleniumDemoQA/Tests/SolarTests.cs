using SeleniumDemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Tests
{
    public class SolarTests: BaseClass
    {
        [Test]
        public void VerifyFiltering()
        {
            // Arrange
            var solarPage = new SolarPage(_driver);
            
            solarPage.Open();
            solarPage.OpenSolarPanels();
            solarPage.OpenFilters();

            // Act
            var firstProductTextBefore = solarPage.GetFirstProductTitleText();
            solarPage.CheckBrand("JA Solar");
            var firstProductTextAfter = solarPage.GetFirstProductTitleText();

            // Assert
            //MyAssert.NotEqual(firstProductTextAfter, firstProductTextBefore);
            Assert.That(firstProductTextAfter, Is.Not.EqualTo(firstProductTextBefore));
        }

    }
}
