using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SpecFlowSeleniumSolarTechnology.Hooks
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly ScenarioContext _scenarioContext;
        public WebDriverHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            options.AddArguments("--disable-search-engine-choice-screen");
            var driver = new ChromeDriver(options);
            var js = (IJavaScriptExecutor)driver;
           
            _scenarioContext["WebDriver"] = driver;
        }
        [AfterScenario]
        public void CloseWebDriver()
        {
            if (_scenarioContext.TryGetValue("WebDriver", out IWebDriver driver))
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
