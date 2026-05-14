using NUnit.Framework;
using TestAuth.Model;

namespace TestAuth.Tests
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void SetupAuth()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);

            app.Auth.Login(user);
            app.Auth.WaitForLoginSuccess();
            app.Navigation.OpenHomePage();
        }
    }
}
