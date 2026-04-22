using OpenQA.Selenium;

namespace TestAuth.Helpers
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/login");
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}