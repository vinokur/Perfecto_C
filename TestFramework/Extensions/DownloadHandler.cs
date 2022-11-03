using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Configuration.Environment_configuration;

namespace TestFramework.Extensions
{
    public static class DownloadHandler
    {
        #region Methods

        /// <summary>
        /// Method for downloading a file from the web page by performing provided action      
        /// </summary>
        public static string DownloadFileFromUI(Action downloadMethod)
        {
            downloadMethod();
           
            return GetCreatedFileName();
        }

        /// <summary>
        /// Method for obtaining a path to a downloaded file
        /// </summary>
        public static string GetCreatedFileName()
        {
            var filePath = TestEnvironment.Context.DownloadFolder;

            return new DirectoryInfo(filePath).GetFiles().First().FullName;
        }

        /// <summary>
        /// Method for obtaining a path to a download folder
        /// </summary>        
        public static string GetDownloadFolder()
        {
            var downloadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestResults",
                TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyMMddHHmmss"));

            if (!Directory.Exists(downloadDirectory))
            {
                try
                {
                    Directory.CreateDirectory(downloadDirectory);
                }
                catch (UnauthorizedAccessException ex)
                {
                    throw new UnauthorizedAccessException("User can not create folder", ex.InnerException);
                }
            }

            return downloadDirectory;
        }

        #endregion Methods
    }
}
