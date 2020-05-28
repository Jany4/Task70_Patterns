using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace Patterns
{
    public class TutByEmailPage
    {
        private IWebDriver _driver;
        private string _userName;

        private const string _mailUserNamexPath = "//div[@class=\"mail-User-Name\"]";
        private const string _logoutButtonXPath = "//a[@data-metric=\"Sign out of Yandex services\"]";
        private static string Title = "Входящие — Яндекс.Почта";

        [FindsBy(How = How.XPath, Using = _mailUserNamexPath)]
        private IWebElement _mailUserName;

        [FindsBy(How = How.XPath, Using = _logoutButtonXPath)]
        private IWebElement _logoutButton;

        public TutByEmailPage(IWebDriver driver, string userName)
        {
            _driver = driver;
            _userName = userName;
            PageFactory.InitElements(_driver, this);
        }

        public bool IsLoaded
        {
            get
            {
     //           string uName = _mailUserName.Text;
                return (Waiter.Wait(_driver, By.XPath(_mailUserNamexPath)) && _mailUserName.Text.Equals($"{_userName}@tut.by"));
            }
        }

        public YandexPage LogOut()
        {
            if (IsLoaded)
            {
                _mailUserName.Click();
                _logoutButton.Click();
                return new YandexPage(_driver);
            }
            else
            {
                return null;
            }
        }


    }
}
