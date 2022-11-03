using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using TestFramework.Enums;
using TestFramework.Extensions;

namespace TestFramework.Configuration.Environment_configuration
{
    /// <summary>
    /// Class responsible for environment initialization and loading corresponding configuration
    /// </summary>
    public class TestEnvironment
    {
        #region Fields        

        public string EnvironmentName { get; private set; }
        public string URL { get; private set; }
        public Browser Browser { get; set; }
        public string DownloadFolder { get; set; }
        public string DownloadedFilePath { get; set; }        

        #endregion Fields

        #region Methods

        private TestEnvironment() { }

        public static TestEnvironment Context { get; } = new TestEnvironment();

        /// <summary>
        /// Initializing the test environment. Reading the corresponding configuration and assigning values.
        /// </summary>
        public static void InitializeEnvironment()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var directory = Path.Combine(@"" + outPutDirectory, @"Configuration.xml").ToString();
            var configurationDocument = XDocument.Load(directory);

            var globalConfiguration = configurationDocument.Descendants("GlobalConfiguration").First();

            Context.URL = globalConfiguration.Element("URL").Value;
            Context.DownloadFolder = DownloadHandler.GetDownloadFolder();
            Context.Browser = Browser.Chrome;
        }

        #endregion Metgods
    }
}
