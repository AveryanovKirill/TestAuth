using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAuth
{
    [TestFixture]
    public class FileCreationTests : TestBase
    {
        [Test]
        public void TheCreateFileTest()
        {
            AccountData user = new AccountData("почта", "пароль");
            FileData file = new FileData("Привет");

            OpenLoginPage();
            Login(user);
            WaitForLoginSuccess();

            OpenHomePage();
            OpenCreateFileMenu();
            CreateNewFile(file);
            WaitForSaving();

            Assert.Pass("Файл создан");
        }
    }
}
