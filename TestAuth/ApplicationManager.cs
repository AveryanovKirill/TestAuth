using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using TestAuth.Helpers;

namespace TestAuth
{
    public class ApplicationManager
    {
        private IWebDriver driver;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private FileHelper file;

        private string baseURL;

        public ApplicationManager()
        {
            driver = new EdgeDriver();
            baseURL = "https://dynalist.io";

            navigation = new NavigationHelper(this, baseURL);
            auth = new LoginHelper(this);
            file = new FileHelper(this);
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public NavigationHelper Navigation
        {
            get { return navigation; }
        }

        public LoginHelper Auth
        {
            get { return auth; }
        }

        public FileHelper File
        {
            get { return file; }
        }

        public void Stop()
        {
            driver.Quit();
        }
    }
}