﻿namespace AtataDemoQA
{
    [SetUpFixture]
    public sealed class SetUpFixture
    {
        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            // Find information about AtataContext configuration on https://atata.io/getting-started/#configuration
            AtataContext.GlobalConfiguration
                .UseChrome()
                    .WithArguments(
                        "start-maximized",
                        "disable-search-engine-choice-screen")
                .UseBaseUrl("https://demoqa.com")
                .UseCulture("en-US")
                .UseAllNUnitFeatures();

            AtataContext.GlobalConfiguration.AutoSetUpDriverToUse();
        }
    }
}
