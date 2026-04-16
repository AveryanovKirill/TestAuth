using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text;
namespace SeleniumTests
{
//    [TestFixture]
//    public class LoginTest
//    {
//        private IWebDriver driver;
//        private StringBuilder verificationErrors;
//        private string baseURL;
//        private bool acceptNextAlert = true;

//        [SetUp]
//        public void SetupTest()
//        {
//            driver = new EdgeDriver();
//            baseURL = "https://www.google.com/";
//            verificationErrors = new StringBuilder();
//        }
  
//        [TearDown]
//        public void TeardownTest()
//        {
//            driver.Quit();
//        }

//        [Test]
//        public void TheLoginTest()
//        {
//            driver.Navigate().GoToUrl("https://www.figma.com/signup");

//            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

//            var emailInput = wait.Until(
//                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email"))
//            );
//            driver.FindElement(By.Id("email")).SendKeys("kbaveryanov@stud.kpfu.ru");
//            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
//            var passwordInput = wait.Until(
//                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("current-password"))
//            );
//            driver.FindElement(By.Id("current-password")).SendKeys("g_Umjt6Z_Ws3wEy");
//            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
//            try
//            {
//                var recents = wait.Until(
//                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Recents')]")));
//                Assert.That(recents.Text, Is.EqualTo("Recents"));
//            }
//            catch (AssertionException e)
//            {
//                verificationErrors.Append(e.Message);
//            }
//        }
//    }
}
