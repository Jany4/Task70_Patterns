using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace Patterns
{
    public class TutByLoginPage
    {
        private static string _url = "https://mail.tut.by/";

        private const string _loginLineId = "Username";
        private const string _passwordLineId = "Password";
        private const string _logInButtonXPath = "//input[contains(@class, \"loginButton\")]";

        private IWebDriver _driver;

        private static string _title = "TUT.BY | ВАША ПОЧТА ТУТ | Вход";

        [FindsBy(How = How.Id, Using = _loginLineId)]
        private IWebElement _loginLine;

        [FindsBy(How = How.Id, Using = _passwordLineId)]
        private IWebElement _passwordLine;

        [FindsBy(How = How.XPath, Using = _logInButtonXPath)]
        private IWebElement _logInButton;

        
        public TutByLoginPage(IWebDriver driver)
        {
            _driver = driver;
            Load();
            PageFactory.InitElements(_driver, this);
        }

        public void Load()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public bool IsLoaded
        {
            get { return (Waiter.Wait(_driver, By.Id(_loginLineId)) && _driver.Title.Equals(_title)); }
        }

        public TutByEmailPage LogIn(string logInString, string passwordString)
        {
            if (IsLoaded)
            {
                _loginLine.SendKeys(logInString);
                _passwordLine.SendKeys(passwordString);
                _logInButton.Click();

                return new TutByEmailPage(_driver, logInString);
            }
            else
            {
                return null;
            }
        }
    }
}
