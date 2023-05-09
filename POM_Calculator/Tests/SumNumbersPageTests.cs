using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverCalculatorPOM.Pages;

namespace WebDriverCalculatorPOM.Tests
{
    public class SumNumbersPageTests : BaseTest
    {
       
        private SumNumbersPage page;
        
        [SetUp]
        public void Setup()
        { 

            page = new SumNumbersPage(driver);

            page.Open();
        }
       
    

        [Test]
        public void Test_SumNumbersPage_CheckTitle()
        {


            Assert.That(page.GetPageTitle(), Is.EqualTo("Number Calculator"));

           
        }

        [Test]
        public void Test_SumNumbersPage_SumTwoPositiveNumbers()
        {

            page.CalculateNumbers("4", "+", "5");
            Assert.That(page.ResultLabel.Text, Is.EqualTo("Result: 9"));


        }

        [Test]
        public void Test_MultiplyNumbersPage_SumTwoPositiveNumbers()
        {

            page.CalculateNumbers("4", "*", "5");
            Assert.That(page.ResultLabel.Text, Is.EqualTo("Result: 20"));


        }

        [Test]

        public void Test_SumILettersAndNumbers()
        {
            page.CalculateNumbers("3", "+", "addsdasd");
            Assert.That(page.ResultLabel.Text, Is.EqualTo("Result: invalid input"));
        }

        [Test]

        public void Test_CheckResetButton()
        {
            page.CalculateNumbers("2", "+", "3");
            page.ResetButtonClick();
            Assert.True(page.IsFormEmpty());


            Task.Delay(5000).Wait();
        }
    }
}
