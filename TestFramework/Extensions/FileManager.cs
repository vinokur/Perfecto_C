using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Extensions
{
    public static class FileManager
    {       
        /// <summary>
        /// Method for gettning a list of files from a specified folder path
        /// </summary>
        public static List<string> GetFiles(string folderPath)
        {
            try
            {
                return Directory.GetFiles(folderPath).ToList();
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("User has no access to folder", ex.InnerException);
            }
        }     

        /// <summary>
        /// Method for checking whether the specified file exists
        /// </summary>
        public static bool IsFileAvailable(string filePath)
        {
            try
            {
                return File.Exists(filePath);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("User has no access to folder", ex.InnerException);
            }
        }

        /// <summary>
        /// Method for reading the content of the file into the string
        /// </summary>
        public static string GetFileContent(string filePath)
        {
            string fileContent;

            using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
            {
                fileContent = streamReader.ReadToEnd();
            }

            return fileContent;
        }      
        
    }
}