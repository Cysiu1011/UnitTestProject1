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
    public class SearchResult : HomePage
    {

        public SearchResult(IWebDriver webdriver) : base(webdriver)
        {

        }

        public void result()
        {            
            article_list = webDriver.FindElements(By.XPath("//article"));

            Assert.AreEqual(article_list.Count, 10);

            IWebElement button_next = webDriver.FindElement(By.XPath("/html/body/main/div[1]/section/div/div/div/section/div/div[2]/div[2]/div[1]/ul/li[7]/a"));
            button_next.Click();

            webDriverWait.Until(driver1 => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));

            IList<IWebElement> next_page = webDriver.FindElements(By.XPath("//article"));

            Assert.AreEqual(next_page.Count, 10);

            next_page[2].FindElement(By.ClassName("productItem__name")).Click();
            webDriverWait.Until(driver1 => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
