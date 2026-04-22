using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAuth.Model;

namespace TestAuth.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
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
    }
}