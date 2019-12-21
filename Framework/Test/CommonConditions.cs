using Framework.Driver;
using log4net;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Framework.Test
{
    public class CommonConditions
    {
        protected IWebDriver driver;

        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        [SetUp]
        public void OpenBrowser()
        {
            driver = DriverSingleton.GetDriver();
            Log.Info("Browser opened");
        }

        [TearDown]
        public void StopBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
                TestListener.OnTestFailure();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                TestListener.OnTestSuccess();

            DriverSingleton.CloseDriver();
            Log.Info("Browser closed");
        }
    }
}
