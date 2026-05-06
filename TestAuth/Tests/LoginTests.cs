using NUnit.Framework;
using TestAuth.Model;

namespace TestAuth.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void TheLoginTest()
        {
            AccountData user = new AccountData("почта", "пароль");

            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);
            app.Auth.WaitForLoginSuccess();

            Assert.That(app.Auth.IsLoggedIn(), Is.True);
            Assert.That(app.Driver.Url.Contains("/login"), Is.False);
        }
    }
}