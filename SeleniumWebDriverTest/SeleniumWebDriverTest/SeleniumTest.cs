using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumWebDriverTest
{

    public class Tests
    {
        protected IWebDriver _webDriver;
        protected IWebElement element;
        [OneTimeSetUp]
        protected void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(@"http://automationpractice.com/");
            //Task.Delay(TimeSpan.FromSeconds(1)).Wait();  
        }

        [Test, Order(1)] // Task 1

        public void ViewPageTitle()
        {
            Assert.AreEqual("My Store", _webDriver.Title, "The titles are different");
            TestContext.WriteLine(_webDriver.Title);
        }
        

        [Test, Order(2)]
        public void TabsName()
        {
            List<IWebElement> lst = _webDriver.FindElements(By.XPath("//div[@id='block_top_menu']/ul/li/a")).ToList();
            for (int i = 0; i < lst.Count; i++)
                TestContext.WriteLine(lst[i].Text);
        }



        [Test, Order(3)] //Task 3
        public void SearchFieldName()
        {
            //Assert.AreEqual("search_query", _webDriver.FindElement(By.XPath("//form[@id='searchbox']/input[4]")).GetAttribute("name"), "Incorrect name of SearchField");
            TestContext.WriteLine(_webDriver.FindElement(By.XPath("//form[@id='searchbox']/input[4]")).GetAttribute("name"));
        }

        [Test, Order(4)] //Task 4 
        public void _ClickOnBestSellersTab()
        {
            _webDriver.FindElement(By.XPath("//ul//a[text()='Best Sellers']")).Click();
        }

        [Test, Order(5)] //Task 5

        public void SearchSomething()
        {
            element = _webDriver.FindElement(By.XPath("//form[@id='searchbox']/input[4]"));
            element.Click();
            element.SendKeys("Dress");
            element.SendKeys(Keys.Enter);
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            if (_webDriver != null)
                _webDriver.Quit();
        }
    }
}