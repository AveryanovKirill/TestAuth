using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using TestAuth.Model;

namespace TestAuth.Tests
{
    [TestFixture]
    public class FileCreationTests : TestBase
    {
        public static IEnumerable<FileData> FileDataFromXmlFile()
        {
            using (StreamReader reader = new StreamReader(@"Data\files.xml"))
            {
                return (List<FileData>)new XmlSerializer(typeof(List<FileData>))
                    .Deserialize(reader);
            }
        }

        [Test, TestCaseSource(nameof(FileDataFromXmlFile))]
        public void TheCreateFileTest(FileData file)
        {
            AccountData user = new AccountData("почта", "пароль");

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