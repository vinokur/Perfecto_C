using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Configuration.Environment_configuration;
using TestFramework.Extensions;
using TestFramework.Page_Objects;
using UIParallelTests.Test_Base;

namespace UIParallelTests.Tests
{
    [TestFixture]
    [Category("ParallelTests")]    
    [Parallelizable(ParallelScope.All)]
    public class ParallelTests : TestBase
    {       
        [Test]             
        public void Task1_ValidateBlankBeltProgramFileCanBeDownloaded()
        {           
            new HomePage()
                .GoTo()
                .SelectMenuOption("Services", "Professional Services");
            
            new ProfessionalServicesPage()
                .ExpandConsultingServicesMenu("Black Belt Program");

            TestEnvironment.Context.DownloadedFilePath = DownloadHandler.DownloadFileFromUI(() =>
            {
                new ProfessionalServicesPage().DownloadServiceFile("Black Belt Program");
            });

            Assert.Multiple(() =>
            {
                Assert.IsTrue(FileManager.IsFileAvailable(TestEnvironment.Context.DownloadedFilePath), "File is not downloaded.");
                
                var files = FileManager.GetFiles(TestEnvironment.Context.DownloadFolder);
                Assert.AreEqual(1, files.Count, "The number of downloaded files doesn't match expected.");
            });
        }

        [Test]       
        public void Task2_ValidateSelectedOptionsTitleMatchesBlog()
        {
            new HomePage()
                .GoTo()
                .SelectTopHeaderMenuOption("Blog");

            new BlogPage()
                .EnterSearchValue("Quantum")
                .GetAvailableSearchDropDownOptions(out List<string> options)
                .SelectFirstSearchSuggestion();

            var actualTitle = new ArticlePage().GetArticleTitle();

            Assert.AreEqual(options.First(), actualTitle, "The actual title does not match expected.");
        }

    }
}

