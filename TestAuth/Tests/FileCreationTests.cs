using NUnit.Framework;
using TestAuth.Model;

namespace TestAuth.Tests
{
    [TestFixture]
    public class FileCreationTests : TestBase
    {
        [Test]
        public void TheCreateFileTest()
        {
            AccountData user = new AccountData("почта", "пароль");
            FileData file = new FileData("Привет");

            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);
            app.Auth.WaitForLoginSuccess();

            app.Navigation.OpenHomePage();
            app.File.OpenCreateFileMenu();
            app.File.CreateNewFile(file);
            app.File.WaitForSaving();

            Assert.That(app.Auth.IsLoggedIn(), Is.True);
        }
    }
}