using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UITestPractice
{
    public class WaitTests
    {

        private WebDriver driver;
        private const string baseUrl = "http://www.uitestpractice.com/";
        private WebDriverWait wait;


        [SetUp]
        public void Setup()
        {

           
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = baseUrl;


        }

        [TearDown]
        public void Teardown() 
        {
        
        driver.Quit();
        }

        [Test]
        public void Test_ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            var AjaxCallButton = driver.FindElement(By.PartialLinkText("Call"));
            AjaxCallButton.Click();
            var AjaxLink = driver.FindElement(By.PartialLinkText("Ajax link"));
            AjaxLink.Click();
            
            var textElement = driver.FindElement(By.ClassName("ContactUs"));

            Assert.IsTrue(textElement.Displayed);

            driver.Navigate().Refresh();
           
            AjaxLink = driver.FindElement(By.PartialLinkText("Ajax link"));
            AjaxLink.Click();
       
            textElement = driver.FindElement(By.ClassName("ContactUs"));
            
            Assert.IsTrue(textElement.Displayed);
        }

        [Test]
        public void Test_ExplicittWait()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var AjaxCallButton = driver.FindElement(By.PartialLinkText("Call"));
            AjaxCallButton.Click();
            var AjaxLink = driver.FindElement(By.PartialLinkText("Ajax link"));
            AjaxLink.Click();


            var textElement = wait.Until(d =>
            {
                return d.FindElement(By.ClassName("ContactUs"));

            });

            //var textElement = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElement.Text.Contains("Selenium is a portable software testing"));

            
        }


        [Test]
        public void Test_Expected_ConditiontWait()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var AjaxCallButton = driver.FindElement(By.PartialLinkText("Call"));
            AjaxCallButton.Click();
            var AjaxLink = driver.FindElement(By.PartialLinkText("Ajax link"));
            AjaxLink.Click();


            var textElement = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ContactUs")));  

           //var textElement = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElement.Text.Contains("Selenium is a portable software testing"));


        }


    }
}