
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFramework.Configuration;
using TestFramework.Configuration.Environment_configuration;

namespace UITests.Hooks
{
    [Binding]
    public class BaseHooks
    {
        #region Context

        public static ScenarioContext _scenarioContext { private set; get; }
        public static FeatureContext _featureContext { private set; get; }
        public BaseHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        #endregion Context

        #region Before

        /// <summary>
        /// This is run once per thread
        /// </summary>
        [BeforeTestRun]
        [SetUp]
        public static void TestRunSetup()
        {
            TestEnvironment.InitializeEnvironment();
        }        

        #endregion Before

        #region After                             

        [AfterScenario]
        [TearDown]
        public static void QuitDriver()
        {
            DriverFactory.QuitDriver();
        }

        #endregion After      

    }
}
