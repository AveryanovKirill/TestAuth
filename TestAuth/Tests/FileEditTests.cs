using NUnit.Framework;
using TestAuth.Model;

namespace TestAuth.Tests
{
    [TestFixture]
    public class FileEditTests : TestBase
    {
        [Test]
        public void UserRemainsLoggedInAfterCreatingNewFile()
        {
            AccountData user = new AccountData("почта", "пароль");
            FileData draft = new FileData("План на неделю");

            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);
            app.Auth.WaitForLoginSuccess();

            Assert.That(app.Auth.IsLoggedIn(), Is.True, "Пользователь не авторизовался");

            app.Navigation.OpenHomePage();
            app.File.OpenCreateFileMenu();
            app.File.CreateNewFile(draft);
            app.File.WaitForSaving();

            app.Navigation.OpenHomePage();

            Assert.That(app.Auth.IsLoggedIn(), Is.True, "После создания файла пользователь разлогинился");
            Assert.That(app.Driver.Url.Contains("/login"), Is.False, "Произошел возврат на страницу логина");
        }
    }
}