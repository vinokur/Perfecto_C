using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TestFramework.Extensions;

namespace TestFramework.Page_Objects
{
    public class BlogPage : BasePage
    {
        #region Locators

        By SearchInputField = By.Id("edit-blog-title");
        By FirstSuggestionFromSearchListField = By.XPath("//form[@id = 'views-exposed-form-blog-with-featured']/ul[contains(@class, 'ui-menu')]/li[contains(@class, 'ui-menu-item-first')]");
        By DropDownSearchOption = By.XPath("//form[@id = 'views-exposed-form-blog-with-featured']/ul[contains(@class, 'ui-menu')]/li[contains(@class, 'ui-menu-item')]/a//div[@class = 'ui-autocomplete-field-title']");
        
        #endregion Locators

        #region Methods      

        /// <summary>
        /// Method for entering a specified search value to an input field on a 'Blog' page
        /// </summary>        
        public BlogPage EnterSearchValue(string inputValue)
        {
            Driver.FindElement(SearchInputField).SendKeys(inputValue);
            return this;
        }

        /// <summary>
        /// Method for selecting first search suggestion from a list
        /// </summary>        
        public void SelectFirstSearchSuggestion()
        {
            try
            {
                Driver.FindElement(FirstSuggestionFromSearchListField).Click();                    
            }
            catch
            {
                if(Driver.FindElements(FirstSuggestionFromSearchListField).Count > 0)
                {
                    Driver.FindElement(SearchInputField).SendKeys(Keys.Space);
                    WaitExtension.Delay(2);
                    Driver.FindElement(FirstSuggestionFromSearchListField).ClickByJS();
                }                    
                else
                    throw new NoSuchElementException("No corresponding suggestion found in a list");
            }
        }

        /// <summary>
        /// Method for getting the list of available list options from search drop down
        /// </summary>        
        public BlogPage GetAvailableSearchDropDownOptions(out List<string> values)
        {
            var searchOptions = new List<string>();

            if(!(Driver.FindElements(DropDownSearchOption).Count > 0))
                Driver.FindElement(SearchInputField).SendKeys(Keys.Space);

            Driver.FindElements(DropDownSearchOption).ToList().ForEach(item => searchOptions.Add(item.Text));

            values = searchOptions;

            return this;
        }

        #endregion Methods       
    }
}
