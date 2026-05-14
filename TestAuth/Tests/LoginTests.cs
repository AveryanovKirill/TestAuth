using NUnit.Framework;
using TestAuth.Model;

namespace TestAuth.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);

            app.Auth.Logout();
            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);
            app.Auth.WaitForLoginSuccess();

            Assert.That(app.Auth.IsLoggedIn(), Is.True);
            Assert.That(app.Auth.IsLoggedIn(user.Username), Is.True);
        }

        [Test]
        public void LoginWithInvalidData()
        {
            AccountData user = new AccountData("почта", "пароль");

            app.Auth.Logout();
            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);

            Assert.That(app.Auth.IsLoggedIn(), Is.False);
        }
    }
}
