using System.Threading;
using OpenQA.Selenium;
using TestAuth.Model;

namespace TestAuth.Helpers
{
    public class FileHelper : HelperBase
    {
        public FileHelper(ApplicationManager manager)
            : base(manager)
        {
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
        }

        public void WaitForSaving()
        {
            Thread.Sleep(20000);
        }
    }
}