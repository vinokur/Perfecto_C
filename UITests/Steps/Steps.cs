using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestFramework.Configuration.Environment_configuration;
using TestFramework.Extensions;
using TestFramework.Page_Objects;

namespace UITests.Steps
{
    [Binding]
    public class Steps
    {
        #region Context 
       
        public static List<string> SearchDropDownOptions;

        #endregion Context

        #region Given        

        [Given(@"User navigates to home page")]        
        public void GivenUserNavigatesToHomePage()
        {
            new HomePage().GoTo();
        }

        [Given(@"User expands '(.*)' header menu option drop down")]        
        public void GivenUserExpandsHeaderMwnu(string option)
        {
            new HomePage().ExpandHeaderMenuOption(option);
        }

        [Given(@"User selects '(.*)' option from '(.*)' header menu")]
        public void GivenUserSelectsHeaderMenuOption(string option, string headerMenu)
        {
            new HomePage().SelectMenuOption(headerMenu, option);
        }

        [Given(@"User expands '(.*)' option from 'Consulting Services' menu on 'Services' page")]
        public void GivenUserExpandsConsultingServicesMenu(string menuOption)
        {
            new ProfessionalServicesPage().ExpandConsultingServicesMenu(menuOption);
        }

        [Given(@"User selects '(.*)' top header menu option")]
        public void GivenUserSelectsHeaderMenuOption(string option)
        {
            new HomePage().SelectTopHeaderMenuOption(option);
        }

        #endregion Given

        #region When               

        [When(@"User downloads file for '(.*)' menu option from 'Professional Services page'")]
        public void WhenUserDownloadsRunDetailsData(string menuOption)
        {
            TestEnvironment.Context.DownloadedFilePath = DownloadHandler.DownloadFileFromUI(() =>
            {
                new ProfessionalServicesPage().DownloadServiceFile(menuOption);
            });            
        }

        [When(@"User enters '(.*)' value into the search field of the blog page")]
        public void WhenUseEntersSearchValue(string value)
        {
            new BlogPage().EnterSearchValue(value);
        }

        [When(@"User obtains available search drop down options of the blog page")]
        public void WhenUserObtainsAvailablesearchOptions()
        {
            new BlogPage().GetAvailableSearchDropDownOptions(out List<string> values);
            SearchDropDownOptions = values;            
        }

        [When(@"User selects first suggestion from search drop down list")]
        public void WhenUserSelectsFirstSuggestionFromDropDownList()
        {
            new BlogPage().SelectFirstSearchSuggestion();
        }

        #endregion When

        #region Then             

        [Then(@"File is successfully downloaded from the page")]
        public void ThenDataFromRunDetailsTableIsRefrectedInTheDownloadedFile()
        {
            FileManager.IsFileAvailable(TestEnvironment.Context.DownloadedFilePath);
        }        

        [Then(@"Download folder contains (.*) files")]
        public void ThenDownloadFolderContainsSpecificNumberOfFiles(int expectedNumberOfFiles)
        {
            var files = FileManager.GetFiles(TestEnvironment.Context.DownloadFolder);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedNumberOfFiles, files.Count, "The number of downloaded files doesn't match expected.");                
            });
        }

        [Then(@"The selected option from search list matches blog title")]
        public void ThenBlogTitlematchesExpected()
        {
            var actualTitle = new ArticlePage().GetArticleTitle();
            
            Assert.AreEqual(SearchDropDownOptions.First(), actualTitle, "The actual title does not match expected.");
        }

        #endregion Then

    }
}
