using Framework.Driver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Framework.Test
{
    public class CommonConditions
    {
        protected IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = DriverSingleton.GetDriver();
        }

        [TearDown]
        public void StopBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
                TestListener.OnTestFailure();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                TestListener.OnTestSuccess();

            DriverSingleton.CloseDriver();
        }
    }
}
