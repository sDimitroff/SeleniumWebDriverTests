using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumWebDriverTest
{
    public class Tests2
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            //var options = new ChromeOptions();
           // options.AddArgument("--headless");
           // driver = new ChromeDriver(options);
             driver = new ChromeDriver();
             driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void Teardown()
        {
           driver.Quit();
        }

        [Test]
        public void Test_Wikipedia_CheckTitleChromeAfterSearchInput()
        {
            //Arrange
            //driver.Navigate().GoToUrl("https://wikipedia.org");
            driver.Url = "https://wikipedia.org";

     
            //Act
            driver.FindElement(By.Id("searchInput")).SendKeys("QA" + Keys.Enter);
            

            //Assertion
            Assert.That(driver.Title, Is.EqualTo("QA - Wikipedia"));

            

        }

        [Test]
        public void Test_Wikipedia_CheckDeutschLinkName()
        {
            //Arrange
            //driver.Navigate().GoToUrl("https://wikipedia.org");
            driver.Url = "https://wikipedia.org";


            //Get by TagName 
           var allStrongElements = driver.FindElements(By.TagName("Strong"));

           var deutschLink = allStrongElements[4].Text;
            
            //Assertion
            Assert.That(deutschLink, Is.EqualTo("Русский"));

           

            Task.Delay(3000).Wait();

        }


        [Test]
        public void Test_OpenGmailInNewTab()
        {
            
          
            driver.Url = "https://google.com";


            driver.FindElement(By.CssSelector("#L2AGLb > div")).Click();
            
            var gmailElements = driver.FindElement(By.PartialLinkText("Gmail"));

            // Open Gmail link in new tab
            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control).MoveToElement(gmailElements).Click().KeyUp(Keys.Control).Perform();

            // Switch to Gmail opened tab
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Task.Delay(3000).Wait();

            //Assertion that it is switched to the opened tab
            Assert.That(driver.Title, Is.EqualTo("Gmail: Private and secure email at no cost | Google Workspace"));
        

            // Swtich to the first tab
            driver.SwitchTo().Window(driver.WindowHandles[0]);

            //Assertion that it is switched to the first tab
            Assert.That(driver.Title, Is.EqualTo("Google"));

            


           

        }

    }
}





