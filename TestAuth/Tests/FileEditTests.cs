using NUnit.Framework;

using TestAuth.Model;

namespace TestAuth.Tests
{
    [TestFixture]
    public class FileEditTests : AuthBase
    {
        [Test]
        public void UserRemainsLoggedInAfterCreatingNewFile()
        {
            FileData draft = new FileData("План на неделю");

            Assert.That(app.Auth.IsLoggedIn(), Is.True, "Пользователь не авторизовался");

            app.File.OpenCreateFileMenu();
            app.File.CreateNewFile(draft);
            app.File.WaitForSaving();

            app.Navigation.OpenHomePage();

            Assert.That(app.Auth.IsLoggedIn(), Is.True, "После создания файла пользователь разлогинился");
            Assert.That(app.Driver.Url.Contains("/login"), Is.False, "Произошел возврат на страницу логина");
        }
    }
}
