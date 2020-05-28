using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace Patterns
{
    public class Tests
    {
        private static IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Close();
        }

        [TestCase("seleniumtests2", "123456789zxcvbn")]
        [Test]
        public void LogInTest(string logIn, string password)
        {
            TutByLoginPage tutByLoginPage = new TutByLoginPage(_driver);
            Assert.IsTrue(tutByLoginPage.IsLoaded);

            Assert.IsTrue(tutByLoginPage.LogIn(logIn, password).IsLoaded);
        }

        [TestCase("seleniumtests2", "123456789zxcvbn")]
        [Test]
        public void LogOutTest(string logIn, string password)
        {
            TutByLoginPage tutByLoginPage = new TutByLoginPage(_driver);
            Assert.IsTrue(tutByLoginPage.IsLoaded);

            TutByEmailPage tutByEmailPage = tutByLoginPage.LogIn(logIn, password);
            Assert.IsTrue(tutByEmailPage.IsLoaded);
            Assert.IsTrue(tutByEmailPage.LogOut().IsLoaded);

        }
    }
}