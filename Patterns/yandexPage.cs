using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace Patterns
{
    public class YandexPage
    {
        private IWebDriver _driver;

        private static string _title = "Яндекс";
        private static string _url = "https://yandex.by/";

        public YandexPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public bool IsLoaded
        {
            get{ return _driver.Title.Equals(_title); }
        }
    }
}
