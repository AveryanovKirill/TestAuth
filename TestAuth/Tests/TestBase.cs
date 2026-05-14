using NUnit.Framework;

namespace TestAuth.Tests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
            app.Navigation.OpenHomePage();
        }
    }
}
