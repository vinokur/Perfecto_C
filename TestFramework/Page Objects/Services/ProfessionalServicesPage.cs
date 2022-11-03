using OpenQA.Selenium;
using TestFramework.Extensions;

namespace TestFramework.Page_Objects
{
    public class ProfessionalServicesPage : BasePage
    {
        #region Locators

        By ServicesMenuOption(string option) => By.XPath("//div[@id = 'paragraph--type--qa-content-menu-of-consulting-services']//div[@role='tablist']//a[@class='accordion-title']//div[contains(@class, 'field') and contains(text(), '" + option + "')]/ancestor::a");
        By DownloadFilemenuAction(string option) => By.XPath("//div[@id = 'paragraph--type--qa-content-menu-of-consulting-services']//div[@role='tablist']//a[@class='accordion-title']//div[contains(@class, 'field') and contains(text(), '" + option + "')]//following::a[contains(text(), 'Download')][1]");

        #endregion Locators

        #region Methods

        /// <summary>
        /// Method for expanding specified menu option
        /// </summary>
        public ProfessionalServicesPage ExpandConsultingServicesMenu(string menuOption)
        {
            if (bool.Parse(Driver.FindElement(ServicesMenuOption(menuOption)).GetAttribute("aria-expanded")) != true)
            {
                try
                {
                    Driver.FindElement(ServicesMenuOption(menuOption)).Click();
                }
                catch
                {
                    Driver.FindElement(ServicesMenuOption(menuOption)).ClickByJS();
                }
            }
            
            return this;
        }

        /// <summary>
        /// Method for downloading a file for a specified mneu option
        /// </summary>
        public ProfessionalServicesPage DownloadServiceFile(string menuOption)
        {            
            try
            {
                Driver.FindElement(DownloadFilemenuAction(menuOption)).Click();
            }
            catch
            {
                if(Driver.FindElements(DownloadFilemenuAction(menuOption)).Count > 0)
                    Driver.FindElement(DownloadFilemenuAction(menuOption)).ClickByJS();
                else
                    throw new NoSuchElementException("Specified menu item does not contain option for downloading a file");
            }

            WaitExtension.Delay(5);

            return this;
        }

        #endregion Methods


    }
}
