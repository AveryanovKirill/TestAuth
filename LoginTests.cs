namespace TestAuth
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void TheLoginTest()
        {
            AccountData user = new AccountData("почта", "пароль");

            OpenLoginPage();
            Login(user);
            WaitForLoginSuccess();

            Assert.That(driver.Url.Contains("/login"), Is.False);
        }
    }
}
