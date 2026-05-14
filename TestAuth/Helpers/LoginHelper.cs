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
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                {
                    return;
                }
                Logout();
            }

            if (!IsElementPresent(By.XPath("//input[@type='email']")))
            {
                manager.Navigation.OpenLoginPage();
            }

            driver.FindElement(By.XPath("//input[@type='email']")).Clear();
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys(user.Username);

            driver.FindElement(By.XPath("//input[@type='password']")).Clear();
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys(user.Password);

            IWebElement signInButton = WaitElement(By.XPath("//input[@value='Sign in']"));
            signInButton.Click();
        }

        public void Logout()
        {
            if (!IsLoggedIn())
            {
                return;
            }

            driver.Navigate().GoToUrl(Settings.BaseURL + "/logout");
            manager.Navigation.OpenLoginPage();
        }

        public void WaitForLoginSuccess()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(drv => !drv.Url.Contains("/login"));
        }

        public bool IsLoggedIn()
        {
            if (driver.Url.Contains("/login"))
            {
                return false;
            }

            if (IsElementPresent(By.XPath("//input[@type='email']")))
            {
                return false;
            }

            return IsElementPresent(By.CssSelector("div.Pane-headerToolbarItem.Pane-headerToolbarItem--newFile"))
                || IsElementPresent(By.CssSelector(".Pane-headerToolbarItem--newFile"));
        }

        public bool IsLoggedIn(string username)
        {
            return IsLoggedIn() && driver.PageSource.Contains(username);
        }
    }
}
