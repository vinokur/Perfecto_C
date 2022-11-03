using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using System;
using System.Threading;
using TestFramework.Configuration.Environment_configuration;
using TestFramework.Enums;

namespace TestFramework.Configuration
{
    public class DriverFactory
    {
        /// <summary>
        /// Thread-local storage of web driver instances for successfully running tests in parallel
        /// </summary>
        private static ThreadLocal<IWebDriver> ThreadDriver = new ThreadLocal<IWebDriver>();

        /// <summary>
        /// Getting and initializing instance of web driver
        /// </summary>
        public static IWebDriver WebDriver
        {
            get
            {
                IWebDriver currentDriver = ThreadDriver.Value;

                if (currentDriver == null)
                {
                    switch (TestEnvironment.Context.Browser)
                    {
                        case Browser.Chrome:
                            currentDriver = new ChromeDriver(DriverCapabilities.GetChromeDriverOptions());
                            ThreadDriver.Value = currentDriver;
                            break;
                        case Browser.InternetExplorer:
                            currentDriver = new InternetExplorerDriver(DriverCapabilities.GetInternetExplorerOptions());
                            ThreadDriver.Value = currentDriver;
                            break;
                        case Browser.Edge:
                            currentDriver = new EdgeDriver(DriverCapabilities.GetEdgeOptions());
                            ThreadDriver.Value = currentDriver;
                            break;


                    }
                }

                ThreadDriver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                return ThreadDriver.Value;
            }
        }

        /// <summary>
        /// Getting javascript executor from web driver
        /// </summary>
        public static IJavaScriptExecutor JavaScriptExecutor
        {
            get
            {
                return ThreadDriver.Value as IJavaScriptExecutor;
            }
        }

        /// <summary>
        /// Method used to quit driver on a tear down
        /// </summary>
        public static void QuitDriver()
        {
            IWebDriver currentDriver = ThreadDriver.Value;

            if (currentDriver != null)
            {
                currentDriver.Quit();
                ThreadDriver.Value = null;
            }
        }
    }
}
