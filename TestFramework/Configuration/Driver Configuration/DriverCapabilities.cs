using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using TestFramework.Configuration.Environment_configuration;

namespace TestFramework.Configuration
{
    public class DriverCapabilities
    {
        /// <summary>
        /// Getting Chrome Driver Options 
        /// </summary>
        public static ChromeOptions GetChromeDriverOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--test-type");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false); 
            chromeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            chromeOptions.AddUserProfilePreference("download.default_directory", TestEnvironment.Context.DownloadFolder);

            return chromeOptions;
        }

        /// <summary>
        /// Getting IE Driver Options 
        /// </summary>
        public static InternetExplorerOptions GetInternetExplorerOptions()
        {
            var ieOptions = new InternetExplorerOptions 
            { 
                IgnoreZoomLevel = true               
            };
            
            return ieOptions;
        }

        /// <summary>
        /// Getting Edge Driver Options 
        /// </summary>
        public static EdgeOptions GetEdgeOptions()
        {
            var edgeOptions = new EdgeOptions
            {
              
            };

            return edgeOptions;
        }
    }
}
