using OpenQA.Selenium;
using System;
using TestFramework.Configuration.Environment_configuration;

namespace TestFramework.Page_Objects
{
    public class HomePage : BasePage
    {
        #region Locators
        By TopHeaderMenuOption(string option) => By.XPath("//nav[@id = 'block-secondarynavigation']/ul/li/a[contains(text(), '" + option + "')]");
            
        By HeaderMenuOption(string option) => By.XPath("//nav[@id = 'block-mainnavigationmegamenu']//ul[contains(@class, 'menu') and @data-region='header']/li/span[contains(text(), '" + option + "')]");
        By ServicesMenuOption(string parentMenuOption, string option) => By.XPath("//nav[@id = 'block-mainnavigationmegamenu']//ul[contains(@class, 'menu')]/li/span[contains(text(), '" + parentMenuOption + "')]//following::div[contains(@class, 'menu')][1]//ul/li/a[contains(text(), '" + option + "')]");

        #endregion Locators

        #region Methods

        /// <summary>
        /// Method for navigating to home page
        /// </summary>
        public HomePage GoTo(bool deleteCookies = true)
        {
            if (deleteCookies == true)
                Driver.Manage().Cookies.DeleteAllCookies();

            try
            {
                if (!string.Equals(TestEnvironment.Context.URL, Driver.Url, StringComparison.CurrentCultureIgnoreCase))
                    Driver.Navigate().GoToUrl(TestEnvironment.Context.URL);
            }
            catch (Exception ex)
            {
                throw new Exception("Login failed. Page can not be opened. Exception: " + ex.Message);
            }

            Console.WriteLine("Login page successfully loaded.");

            return this;
        }

        /// <summary>
        /// Method for expanding header menu option drop down
        /// </summary>
        public HomePage ExpandHeaderMenuOption(string menuOption)
        {
            if(!Driver.FindElement(HeaderMenuOption(menuOption)).GetAttribute("class").Contains("active"))
                Driver.FindElement(HeaderMenuOption(menuOption)).Click();

            return this;
        }
            
        /// <summary>
        /// Method foe selecting services menu option from the header
        /// </summary>        
        public void SelectMenuOption(string parentMenuOption, string servicesmenuOption)
        {
            ExpandHeaderMenuOption(parentMenuOption);
            Driver.FindElement(ServicesMenuOption(parentMenuOption, servicesmenuOption)).Click();
        }

        /// <summary>
        /// Method foe selecting services menu option from the header
        /// </summary>        
        public void SelectTopHeaderMenuOption(string menuOtion)
        {
            Driver.FindElement(TopHeaderMenuOption(menuOtion)).Click();
        }

        #endregion Methods       
    }
}
