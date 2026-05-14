using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using TestAuth.Helpers;

namespace TestAuth
{
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private IWebDriver driver;
        private NavigationHelper navigation;
        private LoginHelper auth;
        private FileHelper file;
        private string baseURL;

        private ApplicationManager()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            baseURL = Settings.BaseURL;

            navigation = new NavigationHelper(this, baseURL);
            auth = new LoginHelper(this);
            file = new FileHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
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

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
