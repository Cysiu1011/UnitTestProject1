using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    public class HomePage
    {
        public IWebDriver webDriver;
        public string url = "http://pearson.com";

        public IList<IWebElement> article_list { get; set; }

        public WebDriverWait webDriverWait;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            webDriverWait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 20));

        }
    

        public SearchResult search()
        {

            this.webDriver.Navigate().GoToUrl(url);
            this.webDriver.Manage().Window.Maximize();

            webDriverWait.Until(driver1 => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));

            IWebElement accept_cookie = webDriver.FindElement(By.CssSelector("#cookie-notification-policy-accept-continue"));
            accept_cookie.Click();

            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='search-box-input']")));
            IWebElement text = webDriver.FindElement(By.XPath("//*[@id='search-box-input']"));

            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/header/div[1]/div[2]/section[2]/div/div/div/div[2]/form/button")));
            IWebElement lupa = webDriver.FindElement(By.XPath("/html/body/header/div[1]/div[2]/section[2]/div/div/div/div[2]/form/button"));

            text.SendKeys("a");
            lupa.Click();

            webDriverWait.Until(driver1 => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));

            return new SearchResult(webDriver);
        }

        public void start()
        {
            SearchResult searchResult = search();
            searchResult.result();

        }


    }
}
