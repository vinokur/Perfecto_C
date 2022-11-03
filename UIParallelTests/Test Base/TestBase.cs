using NUnit.Framework;
using TestFramework.Configuration;
using TestFramework.Configuration.Environment_configuration;

namespace UIParallelTests.Test_Base
{
    public class TestBase
    {       

        #region Set Up

        [SetUp]
        public void SetUp()
        {
            TestEnvironment.InitializeEnvironment();
        }

        #endregion Set Up

        #region Tear down        

        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitDriver();
        }

        #endregion Tear down            
    }
}
