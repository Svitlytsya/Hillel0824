using OpenQA.Selenium;

namespace SpecFlowSeleniumSolarTechnology.Pages
{
    public class HomePage: BasePage
    {
        private string pageUrl = "https://solartechnology.com.ua/shop";
        private By solarPanelsLink = By.CssSelector(".list-inline [href='/shop/solar-panels']");
        private By cableSwitchingLink = By.XPath("//*[@class='list-inline']//a[contains(@href, '/shop/solar-cable')]");
        //private By cartIcon = By.CssSelector("cart-icon");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            NavigateTo(pageUrl);

            WaitForLoader();
        }

        public void OpenSolarPanels()
        {
            WaitAndClickElement(solarPanelsLink);

            WaitForLoader();
        }
       
        public void OpenCableAndSwitching()
        {
            WaitAndClickElement(cableSwitchingLink);
            
            WaitForLoader();

            //try
            //{
            //    Console.WriteLine("Чекаємо елемент...");
            //    WaitForElementVisible(cableSwitchingLink, 15); 
            //    var element = GetElementBy(cableSwitchingLink);
            //    ScrollTo(element);
            //    Console.WriteLine("Елемент знайдено, клікаємо...");
            //    element.Click();
            //    WaitForLoader();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Помилка: {ex.Message}");
            //    throw;
            //}

        }

        public bool IsOnHomePage()
        {
            return _driver.Url.Equals(pageUrl);
        }

    }

}

