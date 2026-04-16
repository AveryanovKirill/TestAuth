using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;


namespace TestAuth
{

    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            driver = new EdgeDriver();
        }

        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
        }

        public IWebElement WaitElement(By by, int seconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(drv =>
            {
                var el = drv.FindElement(by);
                return el.Displayed && el.Enabled ? el : null;
            });
        }

        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl("https://dynalist.io/login");
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://dynalist.io");
        }

        public void Login(AccountData user)
        {
            driver.FindElement(By.XPath("//input[@type='email']")).Clear();
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys(user.Username);
            driver.FindElement(By.XPath("//input[@type='password']")).Clear();
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys(user.Password);

            IWebElement signInButton = WaitElement(By.XPath("//input[@value='Sign in']"));
            signInButton.Click();
        }

        public void WaitForLoginSuccess()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(drv => !drv.Url.Contains("/login"));
        }

        public void OpenCreateFileMenu()
        {
            IWebElement firstButton = WaitElement(By.CssSelector("div.Pane-headerToolbarItem.Pane-headerToolbarItem--newFile"));
            firstButton.Click();

            IWebElement menuItem = WaitElement(By.CssSelector("li.MenuItem.MenuItem--newDocumentUnderRoot"));
            menuItem.Click();

            Thread.Sleep(1000);
        }

        public void CreateNewFile(FileData file)
        {
            Thread.Sleep(1500);

            IWebElement active = driver.SwitchTo().ActiveElement();
            active.Click();
            active.SendKeys(file.Name);

            Thread.Sleep(500);
            active.SendKeys(Keys.Enter);

            Thread.Sleep(20000);
        }

        public void WaitForSaving()
        {
            Thread.Sleep(20000);
        }
    }
}
