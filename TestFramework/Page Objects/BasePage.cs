using OpenQA.Selenium;
using TestFramework.Configuration;

namespace TestFramework.Page_Objects
{
    public abstract class BasePage
    {
        #region Properties

        /// <summary>
        /// Web driver to be referenced by page object classes
        /// </summary>
        protected static IWebDriver Driver
        {
            get
            {
                return DriverFactory.WebDriver;
            }
        }        

        #endregion Properties      

        #region Methods               

        /// <summary>
        /// Method for opening a pabe based on URL provided
        /// </summary>        
        public T OpenPage<T>(string url) where T : new()
        {
            Driver.Navigate().GoToUrl(url);
            return new T();
        }

        #endregion Methods       
    }
}
