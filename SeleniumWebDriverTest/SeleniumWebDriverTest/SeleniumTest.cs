using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;

namespace SeleniumWebDriverTest
{
    [TestFixture]
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
        }
        [Test,Order(2)] // Task 2 (WOMEN tab)
        public void FirstTabName()
        {
            element = _webDriver.FindElement(By.CssSelector("#block_top_menu > ul > li:nth-child(1) > a"));
            Assert.IsTrue("WOMEN" == element.Text, "The actual name of the tab isn't such as declared");
        }
        
        [Test, Order(2)] // Task 2 (Dresses tab)
        public void SecondTabName()
        {
            element = _webDriver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[2]/a"));
            Assert.IsTrue("DRESSES" == element.Text, "The actual name of the tab isn't such as declared");
        }
        
        [Test, Order(2)] // Task 2 (T-SHIRTS tab)
         public void ThirdTabName()
        {
            element = _webDriver.FindElement(By.XPath("//div[@id='block_top_menu']/ul/li[3]/a"));
            Assert.IsTrue("T-SHIRTS" == element.Text, "The actual name of the tab isn't such as declared");
        }

        [Test, Order(3)] //Task 3
        public void SearchFieldName()
        {
            element = _webDriver.FindElement(By.XPath("//*[@id='search_query_top']"));
            //Assert.AreEqual("search_query", element.GetAttribute("name"), "Incorrect name of SearchField");
            Assert.That(element.GetAttribute("name") == "search_query", "Incorrect name of SearchField");
        }
      
        [Test, Order(4)] //Task 4 
        public void ClickOnBestSellersTab()
        {
            element = _webDriver.FindElement(By.XPath("//ul[@id='home-page-tabs']/li[2]/a"));
            element.Click();
        }

        [Test, Order(5)] //Task 5
        public void SearchSomething()
        {
            element = _webDriver.FindElement(By.XPath("//*[@id='search_query_top']"));
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