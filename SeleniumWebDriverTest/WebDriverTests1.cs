using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace SeleniumWebDriverTest
{
    public class Tests1
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {

           
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Wikipedia_CheckTitleChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "https://wikipedia.org";

            Assert.That(driver.Title, Is.EqualTo("Wikipedia"));

        
        }

        [Test]
        public void Test_Wikipedia_CheckTitle_FireFox()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "https://wikipedia.org";

            Assert.That(driver.Title, Is.EqualTo("Wikipedia"));
           
        }

        [Test]
        public void Test_Wikipedia_CheckTitle_Edge()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "https://wikipedia.org";
            Task.Delay(3000).Wait();
            Assert.That(driver.Title, Is.EqualTo("Wikipedia"));


        }
    }
}





