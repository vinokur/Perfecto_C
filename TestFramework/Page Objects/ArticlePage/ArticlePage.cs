using OpenQA.Selenium;


namespace TestFramework.Page_Objects
{
    public class ArticlePage : BasePage
    {
        #region Locators

        By ArticleTitleField = By.XPath("//div[@class = 'header']//following::span[contains(@class, 'field--name-title')]");
       
        #endregion Locators

        #region Methods      

        /// <summary>
        /// Method for getting the title of the current article
        /// </summary>        
        public string GetArticleTitle()
        {
            return Driver.FindElement(ArticleTitleField).Text;
        }      

        #endregion Methods       
    }
}
