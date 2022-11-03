using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Configuration;

namespace TestFramework.Extensions
{
    public static class WebElementExtension
    {
        /// <summary>
        /// Method used for clicking on the specified element using java script
        /// </summary>
        public static void ClickByJS(this IWebElement element)
        {
            DriverFactory.JavaScriptExecutor.ExecuteScript("arguments[0].click();", element);
        }

        /// <summary>
        /// Method used for scrolling the page down to the specified element
        /// </summary>
        public static void ScrollToViewElement(this IWebElement element)
        {
            DriverFactory.JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        /// <summary>
        /// The methods hovers the mouse on the current element.
        /// Can be used in cases when an element is hardly clickable.
        /// </summary>
        /// <param name="element"></param>
        public static void MouseHoverOnElement(this IWebElement element)
        {
            new Actions(DriverFactory.WebDriver).MoveToElement(element).Perform();
        }

        /// <summary>
        /// Method used for setting the value of the checkbox or any input. 
        /// Delay is used as an exception inside - since specific input fields require a short timeout after clearing and before sending keys to set the value
        /// </summary>
        public static void PopulateField(this IWebElement element, string value, bool clearBeforeTyping = true, bool clickOnElementAtFirst = true)
        {
            if (clickOnElementAtFirst)
            {
                try
                {
                    element.Click();
                }
                catch
                {
                    element.ClickByJS();
                }
            }

            if (clearBeforeTyping)
                DriverFactory.JavaScriptExecutor.ExecuteScript("arguments[0].value = '';", element);            
            
            if (string.IsNullOrEmpty(value)) return;

            element.SendKeys(value);
            element.SendKeys(Keys.ArrowLeft);
        }        
    }
}
