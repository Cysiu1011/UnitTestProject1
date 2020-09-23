using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject1
{
    [TestClass]
    public class KlasaTestowa
    {
        IWebDriver webDriver { get; set; }
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void BeforeTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("webdriver.gecko.driver", "geckodriver.exe");
            this.webDriver = new FirefoxDriver(options);
            this.webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            this.webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TestMethod]
        public void TestMethod1()
        {
            HomePage strona_glowna = new HomePage(this.webDriver);
            strona_glowna.start();
        }


        [TestCleanup()]
        public void AfterTest()
        {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                string dataa = DateTime.UtcNow.ToString().Replace(" ", "_").Replace(".", "_").Replace(":", "_");
                ITakesScreenshot screenshotDriver = webDriver as ITakesScreenshot;
                DirectoryInfo di;
                string DirectoryName = string.Concat("..\\..\\Utils\\" + TestContext.TestName);

                if (Directory.Exists(DirectoryName))
                {
                    var screenShotFileName = $"Screenshot.{TestContext.TestName}_{dataa}.jpg";
                    string file_name = string.Concat(DirectoryName + "\\" + screenShotFileName);
                    screenshotDriver.GetScreenshot().SaveAsFile(file_name.ToString());
                }
                else
                {
                    di = Directory.CreateDirectory(DirectoryName);
                    var screenShotFileName = $"Screenshot.{TestContext.TestName}_{dataa}.jpg";
                    string file_name = string.Concat(DirectoryName + "\\" + screenShotFileName);
                    screenshotDriver.GetScreenshot().SaveAsFile(file_name.ToString());
                }
                webDriver.Quit();
            }
            else
            {
                webDriver.Quit();
            }
        }
    }
}

