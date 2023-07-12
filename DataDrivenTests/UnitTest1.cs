using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenWebDriverTests
{

    
    public class Tests
    {

        private WebDriver driver;

      

        [OneTimeSetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
            driver.Manage().Window.Maximize();
            
        }

        [OneTimeTearDown] 
        public void Teardown() 
        
        {
            driver.Quit();
        }

        [TestCase("10", "+", "15", "Result: 25")]
        [TestCase("12", "+", "12", "Result: 24")]
        [TestCase("12", "-", "2", "Result: 10")]
        [TestCase("adss", "-", "2", "Result: invalid input")]
        public void Test1(string num1, string op, string num2, string expectedResult)
        {

            var firstNumberInput = driver.FindElement(By.Id("number1"));
            var secondNumberInput = driver.FindElement(By.Id("number2"));
            var chooseOperation = driver.FindElement(By.Id("operation"));
            var calculateButton = driver.FindElement(By.Id("calcButton"));
            var resetButton = driver.FindElement(By.Id("resetButton"));
            var resultField = driver.FindElement(By.Id("result"));

            

            resetButton.Click();
            firstNumberInput.SendKeys(num1);
            chooseOperation.SendKeys(op);
            secondNumberInput.SendKeys(num2);

            calculateButton.Click();

            
            
            Assert.That(resultField.Text, Is.EqualTo(expectedResult));
            
        }
    }
}